using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tasks.Context;
using Tasks.Dtos.Task;
using Tasks.Models;
using Tasks.Services.Interfaces;

namespace Tasks.Services
{
    public class TaskService : ITaskService
    {
        private readonly ApplicationDbContext _context;

        public TaskService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TaskReadDto>> GetTasksForUserAsync(int userId, int pageNumber, int pageSize)
        {
            var tasks = await _context.Tasks
                .Where(t => t.UserId == userId)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(t => new TaskReadDto
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    DueDate = t.DueDate,
                    Status = t.Status,
                    UserId = t.UserId
                })
                .ToListAsync();

            return tasks;
        }

        public async Task<TaskReadDto> GetTaskByIdAsync(int taskId, int userId, bool isAdmin)
        {
            var task = await _context.Tasks.FindAsync(taskId);

            if (task == null)
                return null;

            // Check if user owns the task or is admin
            if (!isAdmin && task.UserId != userId)
                return null;

            return new TaskReadDto
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                DueDate = task.DueDate,
                Status = task.Status,
                UserId = task.UserId
            };
        }

        public async Task<TaskReadDto> CreateTaskAsync(TaskCreateDto taskCreateDto, int userId)
        {
            var task = new TaskItem
            {
                Title = taskCreateDto.Title,
                Description = taskCreateDto.Description,
                DueDate = taskCreateDto.DueDate,
                Status = taskCreateDto.Status,
                UserId = userId
            };

            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();

            return new TaskReadDto
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                DueDate = task.DueDate,
                Status = task.Status,
                UserId = task.UserId
            };
        }

        public async Task<bool> UpdateTaskAsync(int taskId, TaskUpdateDto taskUpdateDto, int userId, bool isAdmin)
        {
            var task = await _context.Tasks.FindAsync(taskId);

            if (task == null)
                return false;

            // Check ownership or admin
            if (!isAdmin && task.UserId != userId)
                return false;

            task.Title = taskUpdateDto.Title;
            task.Description = taskUpdateDto.Description;
            task.DueDate = taskUpdateDto.DueDate;
            task.Status = taskUpdateDto.Status;

            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteTaskAsync(int taskId, int userId, bool isAdmin)
        {
            var task = await _context.Tasks.FindAsync(taskId);

            if (task == null)
                return false;

            if (!isAdmin && task.UserId != userId)
                return false;

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}

