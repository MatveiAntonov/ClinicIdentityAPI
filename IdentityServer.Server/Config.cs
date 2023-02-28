using IdentityServer4;
using IdentityServer4.Models;
using System.Diagnostics.Metrics;

namespace IdentityServer.Server
{
    public class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResource("roles", "User role(s)", new List<string> { "role" }),
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("serviceapi.scope", "ServiceAPI Scope")
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[]
            {
                new ApiResource("serviceapi", "ServiceAPI")
                {
                    Scopes = { "serviceapi.scope" },
                    UserClaims = new List<string> { "role" }
                }
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientName= "ServiceClient",
                    ClientId = "serviceclient",
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris = new List<string> { "https://localhost:6007/signin-oidc" },
                    AllowedScopes = 
                    { 
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "roles",
						"serviceapi.scope"
                    },
                    ClientSecrets =
                    {
                        new Secret("ServiceClientSecret".Sha512())
                    },
                    RequirePkce = true,
                    PostLogoutRedirectUris = new List<string> { "https://localhost:6007/signout-callback-oidc" },
                    RequireConsent = true,
                    ClientUri = "https://localhost:6007",
                    AccessTokenLifetime = 120,
                    AllowOfflineAccess = true,
                    UpdateAccessTokenClaimsOnRefresh = true
                }
            };
    }
}
