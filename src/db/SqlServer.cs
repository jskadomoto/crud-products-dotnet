using Microsoft.EntityFrameworkCore;

public class ApplicationDBContext : DbContext
{
  public DbSet<Product> Products { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder options)
  {
    var connectionString = Config.GetConnectionString("DefaultConnection");
    options.UseSqlServer(connectionString);
  }
}