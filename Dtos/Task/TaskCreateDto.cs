using System;
using System.ComponentModel.DataAnnotations;

namespace Tasks.Dtos.Task
{
    public class TaskCreateDto
    {
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }
        
        public DateTime? DueDate { get; set; }

        [Required]
        public string Status { get; set; } // "Pending", "Completed", etc.

        [Required]
        public int UserId { get; set; } // Foreign key
    }
}
