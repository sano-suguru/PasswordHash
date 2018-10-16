using Microsoft.AspNetCore.Mvc;
using PasswordHash.App.Services;

namespace PasswordHash.App.Controllers {
  [Route("api/[controller]")]
  [ApiController]
  public class LoginController : ControllerBase {
    readonly IUserService userService;

    public LoginController(IUserService userService) {
      this.userService = userService;
    }

    [HttpPost]
    public IActionResult Authenticate([FromBody]AuthenticateRequest request) {
      bool ok = userService.Authenticate(request.UserName, request.RawPassword);
      return ok ? Ok() : (IActionResult)Unauthorized();
    }
  }

  public class AuthenticateRequest {
    public string UserName { get; set; }
    public string RawPassword { get; set; }
  }
}