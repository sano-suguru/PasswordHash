namespace PasswordHash.App.Services {
  public interface IUserService {
    bool Register(string username, string rawPassword);
    bool Authenticate(string username, string rawPassword);
  }
}
