using Microsoft.AspNetCore.Mvc;
using PasswordHash.App.Models;

namespace PasswordHash.App.Services {
  interface IUserService {
    bool Register([FromBody] string username, [FromBody] string rawPassword);
    bool Authenticate([FromBody] string username, [FromBody] string rawPassword);
  }
}
