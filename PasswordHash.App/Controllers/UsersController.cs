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
    public IActionResult RegisterUser([FromBody]RegisterUserRequest request) {
      bool success = userService.Register(request.UserName, request.RawPassword);
      return success ? Ok() : (IActionResult)Conflict();
    }
  }

  public class RegisterUserRequest {
    public string UserName { get; set; }
    public string RawPassword { get; set; }
  }
}