using IdentityModel;
using IdentityServer.Client.Handlers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using System.IdentityModel.Tokens.Jwt;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient("APIClient", client =>
{
    client.BaseAddress = new Uri("https://localhost:5001/");
    client.DefaultRequestHeaders.Clear();
    client.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
}).AddHttpMessageHandler<BearerTokenHandler>();

builder.Services.AddHttpClient("IDPClient", client =>
{
    client.BaseAddress = new Uri("https://localhost:5005/");
    client.DefaultRequestHeaders.Clear();
    client.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
}).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, opt =>
{
    opt.AccessDeniedPath = "/Auth/AccessDenied";
})
.AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, options =>
{
    options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.Authority = "https://localhost:5005";
    options.ClientId = "serviceclient";
    options.ResponseType = OpenIdConnectResponseType.Code;
    options.SaveTokens = true;
    options.ClientSecret = "ServiceClientSecret";
    options.GetClaimsFromUserInfoEndpoint = true;
    options.ClaimActions.DeleteClaims(new string[] { "sid", "idp"});
    options.Scope.Add("address");
    options.Scope.Add("roles");
    options.ClaimActions.MapUniqueJsonKey("role", "role");
    options.Scope.Add("serviceapi.scope");
    options.Scope.Add("country");
	options.ClaimActions.MapUniqueJsonKey("country", "country");
    options.Scope.Add("offline_access");
	options.TokenValidationParameters = new TokenValidationParameters
    {
        RoleClaimType = JwtClaimTypes.Role
    };
});

builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient<BearerTokenHandler>();

builder.Services.AddAuthorization(authOpt =>
{
    authOpt.AddPolicy("CanCreateAndModifyData", policyBuilder =>
    {
        policyBuilder.RequireAuthenticatedUser();
        policyBuilder.RequireRole("role", "Administrator");
        policyBuilder.RequireClaim("country", "USA");
    });
}); 

builder.Services.AddControllersWithViews();

var app = builder.Build();

JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
