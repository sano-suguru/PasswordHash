using Microsoft.AspNetCore.Mvc;
using PasswordHash.App.Services;

namespace PasswordHash.App.Controllers {
  [Route("api/[controller]")]
  [ApiController]
  public class LoginController : ControllerBase {
    private readonly IUserService userService;

    public LoginController(IUserService userService) {
      this.userService = userService;
    }

    public IActionResult Authenticate([FromBody] string username, [FromBody] string rawPassword) {
      bool ok = userService.Authenticate(username, rawPassword);
      if (ok) {
        return Ok();
      } else {
        return Unauthorized();
      }
    }
  }
}