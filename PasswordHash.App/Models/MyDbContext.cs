using Microsoft.EntityFrameworkCore;

namespace PasswordHash.App.Models {
  public class MyDbContext : DbContext {
    public MyDbContext(DbContextOptions<MyDbContext> options)
      : base(options) { }

    public DbSet<User> Users { get; set; }
  }
}
