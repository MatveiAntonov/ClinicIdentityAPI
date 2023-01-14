using IdentityServer4.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace IdentityServer.Server.Entities.ViewModels
{
    public class UserRegistrationModel
    {
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }

        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Birth Date is required")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

    }
}
