using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using Tasks.Dtos.Task;
using Tasks.Services.Interfaces;

namespace Tasks.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        private int GetUserId()
        {
            return int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        }

        private bool IsAdmin()
        {
            return User.IsInRole("Admin");
        }

        [HttpGet]
        public async Task<IActionResult> GetTasks([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var userId = GetUserId();
            var tasks = await _taskService.GetTasksForUserAsync(userId, pageNumber, pageSize);
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTask(int id)
        {
            var userId = GetUserId();
            var isAdmin = IsAdmin();

            var task = await _taskService.GetTaskByIdAsync(id, userId, isAdmin);
            if (task == null) return NotFound();

            return Ok(task);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask(TaskCreateDto taskCreateDto)
        {
            var userId = GetUserId();

            var createdTask = await _taskService.CreateTaskAsync(taskCreateDto, userId);
            return CreatedAtAction(nameof(GetTask), new { id = createdTask.Id }, createdTask);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, TaskUpdateDto taskUpdateDto)
        {
            var userId = GetUserId();
            var isAdmin = IsAdmin();

            var result = await _taskService.UpdateTaskAsync(id, taskUpdateDto, userId, isAdmin);
            if (!result) return Forbid();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var userId = GetUserId();
            var isAdmin = IsAdmin();

            var result = await _taskService.DeleteTaskAsync(id, userId, isAdmin);
            if (!result) return Forbid();

            return NoContent();
        }
    }
}
