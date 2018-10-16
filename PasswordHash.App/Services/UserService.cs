using PasswordHash.App.Models;
using PasswordHash.Lib;
using System.Linq;

namespace PasswordHash.App.Services {
  public class UserService : IUserService {
    readonly MyDbContext dbContext;
    readonly IPasswordService passwordService;

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
      var user = new User {
        Name = username,
        HashedPassword = hashed,
        Salt = salt
      };
      dbContext.Users.Add(user);
      dbContext.SaveChanges();
      return true;
    }

    public bool Authenticate(string username, string rawPassword) {
      var user = dbContext.Users.SingleOrDefault(u => u.Name == username);
      return !(user is null) && passwordService.VerifyPassword(user.HashedPassword, rawPassword, user.Salt);
    }
  }
}
