# PasswordHash

パスワードをハッシュ化してDB登録するサンプル。
ハッシュ化には`Microsoft.AspNetCore.Cryptography.KeyDerivation`を使っています。

```cs
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
    public bool VerifyPassword(string hashedPassword, string rawPassword, byte[] salt) =>
      hashedPassword == HashPassword(rawPassword, salt);

    private string HashPassword(string rawPassword, byte[] salt) =>
      Convert.ToBase64String(
        KeyDerivation.Pbkdf2(
          password: rawPassword,
          salt: salt,
          prf: KeyDerivationPrf.HMACSHA512,
          iterationCount: 10000,
          numBytesRequested: 256 / 8));

    private byte[] GetSalt() {
      using (var gen = RandomNumberGenerator.Create()) {
        var salt = new byte[128 / 8];
        gen.GetBytes(salt);
        return salt;
      }
    }
  }
}
```

## テスト

```sh
cd PasswordHash
dotnet test PasswordHash.Lib.Test
```

## ユーザー登録と認証

アプリの起動

```sh
cd PasswordHash
dotnet run -p PasswordHash.App
```

POST で登録と認証

```sh
# 登録
curl -X POST -H "Content-Type: application/json" -d '{"UserName": "testuser", "RawPassword": "mypassword"}'　localhost:5001/api/users

# 認証
curl -X POST -H "Content-Type: application/json" -d '{"UserName": "testuser", "RawPassword": "mypassword"}'　localhost:5001/api/login
```
