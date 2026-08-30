using Assignment_8.DTOs;
using Assignment_8.Services;
using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;

namespace Assignment_8.Validators 
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _service;

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
            var result = await _service.UpdateAsync(id, request);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskResponseDto>> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            return Ok(result);
        }
    }
}

