using EmailService;
using IdentityServer.Server;
using IdentityServer.Server.Entities;
using IdentityServer.Server.InitialSeed;
using IdentityServerHost.Quickstart.UI;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(Program));

var emailConfig = builder.Configuration
    .GetSection("EmailConfiguration")
    .Get<EmailConfiguration>();

builder.Services.AddSingleton(emailConfig);
builder.Services.AddScoped<IEmailSender, EmailSender>();

builder.Services.AddControllersWithViews();

var migrationAssembly = typeof(Program).GetTypeInfo().Assembly.GetName().Name;

builder.Services.AddDbContext<UserContext>(options => options
    .UseSqlServer(builder.Configuration.GetConnectionString("identitySqlConnection")));

builder.Services.AddIdentity<User, IdentityRole>(opt =>
{
    opt.Password.RequireNonAlphanumeric = false;
    opt.Password.RequiredLength = 8;
})
    .AddEntityFrameworkStores<UserContext>()
    .AddDefaultTokenProviders();


builder.Services.AddIdentityServer(options =>
{
    options.EmitStaticAudienceClaim = true;
})
    .AddConfigurationStore(opt =>
    {
        opt.ConfigureDbContext = c =>
            c.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection"),
        sql => sql.MigrationsAssembly(migrationAssembly));
    })
    .AddOperationalStore(opt =>
    {
        opt.ConfigureDbContext = o =>
            o.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection"),
        sql => sql.MigrationsAssembly(migrationAssembly));
    })
    .AddAspNetIdentity<User>()
    .AddDeveloperSigningCredential();

builder.Services.Configure<DataProtectionTokenProviderOptions>(opt =>
    opt.TokenLifespan = TimeSpan.FromHours(2));

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.UseIdentityServer();

app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
});

var config = app.Services.GetRequiredService<IConfiguration>();
var connectionString = config.GetConnectionString("identitySqlConnection");
SeedUserData.EnsureSeedData(connectionString);

app.MigrateDatabase();

app.Run();
