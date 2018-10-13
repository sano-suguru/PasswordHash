using Microsoft.AspNetCore.Mvc;
using PasswordHash.App.Services;

namespace PasswordHash.App.Controllers {
  [Route("api/[controller]")]
  [ApiController]
  public class UsersController : ControllerBase {
    private readonly IUserService userService;

    public UsersController(IUserService userService) {
      this.userService = userService;
    }

    [HttpPost]
    public IActionResult RegisterUser([FromBody] string username, [FromBody] string rawPassword) {
      bool success = userService.Register(username, rawPassword);
      if (success) {
        return Ok();
      } else {
        return Conflict();
      }
    }
  }
}