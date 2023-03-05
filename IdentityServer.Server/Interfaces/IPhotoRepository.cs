using IdentityServer.Server.Entities;

namespace IdentityServer.Server.Interfaces
{
	public interface IPhotoRepository
	{
		Task<bool> CreatePhoto(Photo photo);
		bool DeletePhoto(Photo photo);
	}
}
