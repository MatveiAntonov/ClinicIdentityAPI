using System.ComponentModel.DataAnnotations;

namespace IdentityServer.Server.Entities.ViewModels
{
    public class ForgotPasswordModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
