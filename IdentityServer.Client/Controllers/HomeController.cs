using IdentityModel.Client;
using IdentityServer.Client.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System.Security.Claims;
using System.Text.Json;

namespace IdentityServer.Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HomeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Authorize]
        public async Task<IActionResult> Services()
        {
            var httpClient = _httpClientFactory.CreateClient("APIClient");

            var response = await httpClient.GetAsync("1.0/services").ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            var servicesString = await response.Content.ReadAsStringAsync();
            var services = JsonSerializer.Deserialize<List<ServiceViewModel>>(servicesString,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return View(services);
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Administrator")]
		public async Task<IActionResult> Privacy()
		{
            var idpClient = _httpClientFactory.CreateClient("IDPClient");
            var metaDataResponse = await idpClient.GetDiscoveryDocumentAsync();

            var accessToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);

            var response = await idpClient.GetUserInfoAsync(new UserInfoRequest
            {
                Address = metaDataResponse.UserInfoEndpoint,
                Token = accessToken
            });

            if (response.IsError)
            {
                throw new Exception("Problem while fetching data from UserInfo endpoint", response.Exception);
            }

            var addressClaim = response.Claims.FirstOrDefault(c => c.Type.Equals("address"));

            User.AddIdentity(new ClaimsIdentity(new List<Claim>
            {
                new Claim(addressClaim.Type.ToString(), addressClaim.Value.ToString())
            }));

            return View();
        }
    }
}