namespace Tasks.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Tasks")]
    public class TaskItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime? DueDate { get; set; }

        public string Status { get; set; } // "Pending", "Completed", etc.

        // Foreign Key
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; } // Navigation property
    }
}
