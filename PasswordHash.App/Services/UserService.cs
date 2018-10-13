using PasswordHash.App.Models;
using PasswordHash.Lib;
using System.Linq;

namespace PasswordHash.App.Services {
  public class UserService : IUserService {
    private readonly MyDbContext dbContext;
    private readonly IPasswordService passwordService;

    public UserService(MyDbContext dbContext, IPasswordService passwordService) {
      this.dbContext = dbContext;
      this.passwordService = passwordService;
    }

    public bool Register(string username, string rawPassword) {
      bool duplicated = dbContext.Users.Any(u => u.Name == username);
      if (duplicated) {
        return false;
      }
      (string hashed, byte[] salt) = passwordService.HashPassword(rawPassword);
      dbContext.Users.Add(new User {
        Name = username,
        HashedPassword = hashed,
        Salt = salt
      });
      dbContext.SaveChanges();
      return true;
    }

    public bool Authenticate(string username, string rawPassword) {
      var user = dbContext.Users.SingleOrDefault(u => u.Name == username);
      if (user is null) {
        return false;
      }
      return passwordService.VerifyPassword(user.HashedPassword, rawPassword, user.Salt);
    }
  }
}
