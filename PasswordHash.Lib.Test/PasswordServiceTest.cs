using Xunit;

namespace PasswordHash.Lib.Test {
  public class PasswordServiceTest {
    [Fact]
    public void TestVerifyPassword() {

      var rawPassword = "nossa1234";
      var sut = new PasswordService();

      var (hashed, salt) = sut.HashPassword(rawPassword);

      Assert.True(sut.VerifyPassword(rawPassword, hashed, salt));
    }
  }
}
