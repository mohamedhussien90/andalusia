using Assignment_8.DTOs;
using Assignment_8.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;

namespace Assignment_8.Validators 
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _service;
        private readonly IAuthorizationService _authzService;

        public TasksController(ITaskService service) => _service = service;

        [HttpPost]
        public async Task<ActionResult<TaskResponseDto>> Create([FromBody] CreateTaskRequest request)
        {
            var result = await _service.CreateAsync(request);
            // Returns 201 Created and points to the GET endpoint
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TaskResponseDto>> Update(int id, [FromBody] UpdateTaskRequest request)
        {
            var task = await _service.GetByIdAsync(id);
            if (task == null) return NotFound();

            
            var authResult = await _authzService.AuthorizeAsync(User, task, "CanManageTasks");
            if (!authResult.Succeeded) return Forbid(); // Returns 403

            var result = await _service.UpdateAsync(id, request);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskResponseDto>> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var task = await _service.GetByIdAsync(id);
            if (task == null) return NotFound();

            // Run the Authorization Policy to check ownership
            var authResult = await _authzService.AuthorizeAsync(User, task, "CanManageTasks");
            if (!authResult.Succeeded) return Forbid(); // Returns 403

            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}

