using Microsoft.AspNetCore.Mvc;
using System;

namespace PasswordHash.App.Services {
  public class UserService : IUserService {
    public bool Authenticate([FromBody] string username, [FromBody] string rawPassword) => throw new NotImplementedException();
    public bool Register([FromBody] string username, [FromBody] string rawPassword) => throw new NotImplementedException();
  }
}
