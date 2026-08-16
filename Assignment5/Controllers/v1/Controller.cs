using Asp.Versioning;
using Assignment5.Models;
using Microsoft.AspNetCore.Mvc;
namespace Assignment5.Controllers.v1



{
    [ApiController]
    [ApiVersion("1.0", Deprecated = true)]
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
                    IsCompleted = true
                }
            };

            return Ok(tasks);
        }
    }
}
