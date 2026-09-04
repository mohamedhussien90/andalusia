using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_8.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        [HttpGet("users")]
        [Authorize(Roles = "Admin")] 
        public IActionResult GetAllUsers()
        {
            return Ok(new { Message = "Admin Endpoint Reached!" });
        }
    }
}
