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
                new IdentityResources.Address(),
                new IdentityResource("roles", "User role(s)", new List<string> { "role" }),
                new IdentityResource("country", "Your country", new List<string> { "country" })
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
                    RedirectUris = new List<string> { "https://localhost:5010/signin-oidc" },
                    AllowedScopes = 
                    { 
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Address,
                        "roles",
						"serviceapi.scope",
						"country"
					},
                    ClientSecrets =
                    {
                        new Secret("ServiceClientSecret".Sha512())
                    },
                    RequirePkce = true,
                    PostLogoutRedirectUris = new List<string> { "https://localhost:5010/signout-callback-oidc" },
                    RequireConsent = true,
                    ClientUri = "https://localhost:5010",
                    AccessTokenLifetime = 120,
                    AllowOfflineAccess = true,
                    UpdateAccessTokenClaimsOnRefresh = true
                }
            };
    }
}
