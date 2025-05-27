namespace Tasks.Models
{
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public byte[] PasswordHash { get; set; }

        [Required]
        public byte[] PasswordSalt { get; set; }

        [Required]
        public string Role { get; set; } = "User";// "Admin" or "User"

        public virtual ICollection<TaskItem> Tasks { get; set; } // Navigation property
    }
}
