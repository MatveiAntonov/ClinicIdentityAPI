using Microsoft.AspNetCore.Identity;

namespace IdentityServer.Server.Entities
{
    public class User : IdentityUser
    {
        public int? PhotoId { get; set; }
        public Photo? Photo { get; set; }
	}
}
