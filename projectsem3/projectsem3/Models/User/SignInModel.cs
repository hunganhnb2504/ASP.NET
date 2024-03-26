using System.ComponentModel.DataAnnotations;

namespace projectsem3.Models.User
{
    public class SignInModel
    {
        [Required, EmailAddress]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Please enter password")]
        [MaxLength(250)]
        public string? Password { get; set; }
    }
}
