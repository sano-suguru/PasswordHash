namespace PasswordHash.Lib {
  public interface IPasswordService {
    bool VerifyPassword(string rawPassword, string hashedPassword, string saltSring);
    (string hashedPassword, string salt) HashPassword(string rawPassword);
  }
}