namespace PasswordHash.Lib {
  public interface IPasswordService {
    bool CheckPassword(string rawPassword, string hashedPassword, string saltSring);
    (string hashedPassword, string salt) HashPassword(string rawPassword);
  }
}