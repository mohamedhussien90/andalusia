using Asp.Versioning;
using Assignment5.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Assignment5.Controllers.v2
{
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/tasks")]
    public class Controller: ControllerBase
    {
        [HttpGet]
        public ActionResult<List<TaskItem>> GetTasks()
        {
            var tasks = new List<TaskItem>
            {
                new TaskItem
                {
                    Id = 1,
                    Title = "Setup API Versioning",
                    Status = "completed",
                    DueDate = DateTime.UtcNow.AddDays(2),
                    CreatedAt = DateTime.UtcNow.AddDays(-1)
                }
            };

            return Ok(tasks);
        }
    }
}
