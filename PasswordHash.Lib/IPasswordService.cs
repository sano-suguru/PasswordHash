namespace PasswordHash.Lib {
  public interface IPasswordService {
    bool VerifyPassword(string rawPassword, string hashedPassword, byte[] salt);
    (string hashedPassword, byte[] salt) HashPassword(string rawPassword);
  }
}