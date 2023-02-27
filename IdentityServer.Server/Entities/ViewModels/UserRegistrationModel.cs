using IdentityServer4.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace IdentityServer.Server.Entities.ViewModels
{
    public class UserRegistrationModel
    {
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; } = String.Empty;

        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; } = String.Empty;

        public string MiddleName { get; set; } = String.Empty;

        [Required(ErrorMessage = "Birth Date is required")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        public string PhoneNumber { get; set; } = String.Empty;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; } = String.Empty;

		[Required(ErrorMessage = "Please select a file")]
		//[FileExtensions(Extensions = ".jpg,.jpeg,.png", ErrorMessage = "Please select a valid image file (.jpg, .jpeg, .png)")]
		public IFormFile? PhotoFile { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = String.Empty;
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; } = String.Empty;
    }
}