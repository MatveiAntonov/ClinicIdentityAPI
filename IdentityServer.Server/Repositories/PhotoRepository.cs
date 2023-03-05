using IdentityServer.Server.Entities;
using IdentityServer.Server.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IdentityServer.Server.Repositories
{
	public class PhotoRepository : IPhotoRepository
	{
		private readonly UserContext _userDbContext;
		public PhotoRepository(UserContext userContext)
		{
			_userDbContext = userContext;
		}
		public async Task<bool> CreatePhoto(Photo photo)
		{
			try
			{
				_userDbContext.Photos.Add(photo);
				_userDbContext.SaveChanges();
				return true;

			}
			catch
			{
				return false;
			}
		}

		public bool DeletePhoto(Photo photo)
		{
			try
			{
				_userDbContext.Photos.Remove(photo);
				_userDbContext.SaveChanges();

				return true;

			}
			catch
			{
				return false;
			}
		}
	}
}
