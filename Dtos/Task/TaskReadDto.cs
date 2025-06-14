﻿using System;

namespace Tasks.Dtos.Task
{
    public class TaskReadDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime? DueDate { get; set; }

        public string Status { get; set; }

        public int UserId { get; set; }

        public string Username { get; set; }  // Optional for display
    }
}
