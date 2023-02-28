using IdentityServer.Server.Entities.Configuration;
using IdentityServer.Server.EntityTypeConfigurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityServer.Server.Entities
{
    public class UserContext : IdentityDbContext<User>
    {
        public DbSet<Photo> Photos { get; set; }

        public UserContext(DbContextOptions<UserContext> options) 
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new UsersConfiguration());
            builder.ApplyConfiguration(new PhotosConfiguration());
        }
    }
}
