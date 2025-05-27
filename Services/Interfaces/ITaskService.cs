using System.Collections.Generic;
using System.Threading.Tasks;
using Tasks.Dtos.Task;

namespace Tasks.Services.Interfaces
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskReadDto>> GetTasksForUserAsync(int userId, int pageNumber, int pageSize);
        Task<IEnumerable<TaskReadDto>> GetAllTasksAsync(int pageNumber, int pageSize);
        Task<TaskReadDto> GetTaskByIdAsync(int taskId, int userId, bool isAdmin);
        Task<TaskReadDto> CreateTaskAsync(TaskCreateDto taskCreateDto, int userId);
        Task<bool> UpdateTaskAsync(int taskId, TaskUpdateDto taskUpdateDto, int userId, bool isAdmin);
        Task<bool> DeleteTaskAsync(int taskId, int userId, bool isAdmin);
    }
}
