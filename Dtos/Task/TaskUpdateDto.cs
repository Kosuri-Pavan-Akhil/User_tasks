using System;

namespace Tasks.Dtos.Task
{
    public class TaskUpdateDto
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime? DueDate { get; set; }

        public string Status { get; set; }
    }
}
