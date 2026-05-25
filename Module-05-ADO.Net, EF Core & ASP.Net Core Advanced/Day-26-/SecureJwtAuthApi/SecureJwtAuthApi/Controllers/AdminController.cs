using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SecureJwtAuthApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    public class AdminController : ControllerBase
    {
        [HttpGet("stats")]
        public IActionResult GetStats()
        {
            return Ok(new
            {
                Title = "Admin Protected Management Stats",
                TotalUsers = 2,
                SystemStatus = "All services operational.",
                AuthorizedUser = User.Identity?.Name
            });
        }
    }
}
