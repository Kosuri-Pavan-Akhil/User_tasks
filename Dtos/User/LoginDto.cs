using System.ComponentModel.DataAnnotations;

namespace Tasks.Dtos.User
{
    public class LoginDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
