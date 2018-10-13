using Microsoft.AspNetCore.Mvc;

namespace PasswordHash.App.Services {
  public interface IUserService {
    bool Register([FromBody] string username, [FromBody] string rawPassword);
    bool Authenticate([FromBody] string username, [FromBody] string rawPassword);
  }
}
