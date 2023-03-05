using IdentityServer.Server.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace IdentityServer.Server.EntityTypeConfigurations
{
    public class PhotosConfiguration : IEntityTypeConfiguration<Photo>
    {
        public void Configure(EntityTypeBuilder<Photo> builder)
        {
            builder.HasKey(photo => photo.Id);
            builder.Property(photo => photo.Id);
			builder.Property(photo => photo.PhotoId).IsRequired();
			builder.HasIndex(photo => photo.PhotoId).IsUnique();
			builder.HasIndex(photo => photo.Id).IsUnique();
            builder.Property(photo => photo.PhotoUrl)
                .IsRequired();
		}
    }
}
