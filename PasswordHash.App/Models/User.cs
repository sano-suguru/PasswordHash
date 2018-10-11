using System.ComponentModel.DataAnnotations;

namespace PasswordHash.App.Models {
  public class User {
    [Key] public string Name { get; set; }
    public byte[] Salt { get; set; }
    public string HashedPassword { get; set; }
  }
}
