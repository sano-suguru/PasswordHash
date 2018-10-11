using System;

namespace PasswordHash.Lib {
  public class PasswordService : IPasswordService {
    public (string hashedPassword, byte[] salt) HashPassword(string rawPassword) => throw new NotImplementedException();
    public bool VerifyPassword(string rawPassword, string hashedPassword, byte[] salt) => throw new NotImplementedException();
  }
}
