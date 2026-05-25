using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SecureJwtAuthApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "User")]
    public class UserController : ControllerBase
    {
        [HttpGet("dashboard")]
        public IActionResult GetDashboard()
        {
            return Ok(new
            {
                Title = "User Protected Dashboard",
                Message = "This endpoint is restricted to authenticated accounts possessing the 'User' role claim.",
                AuthorizedUser = User.Identity?.Name
            });
        }
    }
}
