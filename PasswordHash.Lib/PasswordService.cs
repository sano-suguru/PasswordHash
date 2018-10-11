using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Security.Cryptography;

namespace PasswordHash.Lib {
  public class PasswordService : IPasswordService {
    public (string hashedPassword, byte[] salt) HashPassword(string rawPassword) {
      byte[] salt = GetSalt();
      string hashed = HashPassword(rawPassword, salt);
      return (hashed, salt);
    }
    public bool VerifyPassword(string rawPassword, string hashedPassword, byte[] salt) =>
      hashedPassword == HashPassword(rawPassword, salt);

    string HashPassword(string rawPassword, byte[] salt) =>
      Convert.ToBase64String(
        KeyDerivation.Pbkdf2(
        password: rawPassword,
        salt: salt,
        prf: KeyDerivationPrf.HMACSHA1,
        iterationCount: 10000,
        numBytesRequested: 256 / 8));

    byte[] GetSalt() {
      using (var gen = RandomNumberGenerator.Create()) {
        var salt = new byte[128 / 8];
        gen.GetBytes(salt);
        return salt;
      }
    }
  }
}
