﻿using System;

namespace PasswordHash.Lib {
  public class PasswordService : IPasswordService {
    public bool CheckPassword(string rawPassword, string hashedPassword, string saltSring) => throw new NotImplementedException();
    public (string hashedPassword, string salt) HashPassword(string rawPassword) => throw new NotImplementedException();
  }
}
