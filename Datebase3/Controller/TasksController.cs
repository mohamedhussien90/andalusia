using DataBaseTesting.Models;
using DataBaseTesting.Service;
using DataBaseTestingV2.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace DataBaseTesting.Controller
{
    [ApiController]
    [Route("api/tasks")]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _service;

        public TasksController(ITaskService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<TaskItemDto>>> GetAllTasks()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskItemDto>> GetTaskById(int id)
        {
            var task = await _service.GetByIdAsync(id);
            if (task == null) return NotFound();
            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult<TaskItemDto>> CreateTask([FromBody] CreateTaskRequest request)
        {
            // The request parameter no longer allows the client to send an 'id' or 'createdAt' field
            var newTask = await _service.CreateAsync(request);
            return CreatedAtAction(nameof(GetTaskById), new { id = newTask.Id }, newTask);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TaskItemDto>> UpdateTask(int id, [FromBody] UpdateTaskRequest request)
        {
            var updatedTask = await _service.UpdateAsync(id, request);
            if (updatedTask == null) return NotFound();
            return Ok(updatedTask);
        }

       
    }
}
