using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using IdentityServer.Server.Entities;

namespace IdentityServer.Server.EntityTypeConfigurations
{
    public class UsersConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(user => user.Id);
            builder.HasIndex(user => user.Id).IsUnique();
            builder.HasOne(user => user.Photo)
                .WithOne()
                .HasForeignKey<User>(user => user.PhotoId);
        }
    }
}
