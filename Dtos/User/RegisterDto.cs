using System.ComponentModel.DataAnnotations;

namespace Tasks.Dtos.User
{
    public class RegisterDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long.")]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; } // "Admin" or "User"
    }
}
