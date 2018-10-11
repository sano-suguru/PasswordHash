using System;
using System.Security.Cryptography;

namespace PasswordHash.Lib {
  public class PasswordService : IPasswordService {
    public (string hashedPassword, byte[] salt) HashPassword(string rawPassword) => throw new NotImplementedException();
    public bool VerifyPassword(string rawPassword, string hashedPassword, byte[] salt) => throw new NotImplementedException();

    byte[] GetSalt() {
      using (var gen = RandomNumberGenerator.Create()) {
        var salt = new byte[128 / 8];
        gen.GetBytes(salt);
        return salt;
      }
    }
  }
}
