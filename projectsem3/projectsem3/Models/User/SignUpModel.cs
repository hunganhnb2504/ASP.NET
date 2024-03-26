using System.ComponentModel.DataAnnotations;

namespace projectsem3.Models.User
{
    public class SignUpModel
    {
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required, EmailAddress]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Please enter password")]
        [MaxLength(250)]
        public string? Password { get; set; }
        [Required]
        public string? ConfirmPassword { get; set; }
    }
}
