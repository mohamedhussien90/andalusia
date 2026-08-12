using Microsoft.AspNetCore.Mvc;
using WebApplication2.Service;
using WebApplication2.Taskitem;

namespace WebApplication2.Controllers
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
        public ActionResult<List<TaskItem>> GetAllTasks()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<TaskItem> GetTaskById(int id)
        {
            var task = _service.GetById(id);
            return Ok(task);
        }

        [HttpPost]
        public ActionResult<TaskItem> CreateTask([FromBody] TaskItem task)
        {
            var newTask = _service.Create(task);
            return Ok(newTask);
        }

        [HttpPut("{id}")]
        public ActionResult<TaskItem> UpdateTask(int id, [FromBody] TaskItem task)
        {
            var updatedTask = _service.Update(id, task);
            return Ok(updatedTask);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            _service.Delete(id);
            return NoContent();
        }
    }
}
