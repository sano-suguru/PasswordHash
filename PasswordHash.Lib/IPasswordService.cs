namespace PasswordHash.Lib {
  public interface IPasswordService {
    bool VerifyPassword(string hashedPassword, string rawPassword, byte[] salt);
    (string hashedPassword, byte[] salt) HashPassword(string rawPassword);
  }
}