using IdentityModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace IdentityServer.Server.Entities
{
    public class SeedUserData
    {
        public static void EnsureSeedData(string connectionString)
        {
            var services = new ServiceCollection();
            services.AddLogging();
            services.AddDbContext<UserContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddIdentity<User, IdentityRole>(o => {
                o.Password.RequireDigit = false;
                o.Password.RequireNonAlphanumeric = false;
            }).AddEntityFrameworkStores<UserContext>()
            .AddDefaultTokenProviders();

            //using (var serviceProvider = services.BuildServiceProvider())
            //{
            //    using (var scope = serviceProvider
            //    .GetRequiredService<IServiceScopeFactory>().CreateScope())
            //    {
            //        CreateUser(scope, "97a3aa4a-7a89-47f3-9814-74497fb92ccb", "Michail12345",
            //        "Receptionist", "mishka@mail.com");
            //        CreateUser(scope, "64aca900-7bc7-4645-b291-38f1b7b5963c", "Alena12345",
            //        "Patient", "alenka@mail.com");
            //    }
            //}
        }

        private static void CreateUser(IServiceScope scope, string id, string password, string role, string email)
        {
            var userMgr = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
            var user = userMgr.FindByNameAsync(email).Result;
            if (user == null)
            {
                user = new User
                {
                    UserName = email,
                    Email = email,
                    Id = id
                };
                var result = userMgr.CreateAsync(user, password).Result;
                CheckResult(result);

                result = userMgr.AddToRoleAsync(user, role).Result;
                CheckResult(result);

                result = userMgr.AddClaimsAsync(user, new Claim[]
                {
                    new Claim(JwtClaimTypes.Role, role),
                }).Result;
                CheckResult(result);
            }
        }

        private static void CheckResult(IdentityResult result)
        {
            if (!result.Succeeded)
            {
                throw new Exception(result.Errors.First().Description);
            }
        }
    }
}
