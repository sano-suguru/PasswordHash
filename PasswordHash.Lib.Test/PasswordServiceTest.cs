using Xunit;

namespace PasswordHash.Lib.Test {
  public class PasswordServiceTest {
    [Fact]
    public void TestVerifyPassword() {
      // arange
      var rawPassword = "nossa1234";
      var sut = new PasswordService();  // sut means System Under Test
      // act
      var (hashed, salt) = sut.HashPassword(rawPassword);
      // assert
      Assert.True(sut.VerifyPassword(hashed, rawPassword, salt));
    }
  }
}
