using Microsoft.EntityFrameworkCore;

public class ApplicationDBContext : DbContext
{
  public DbSet<Product> Products { get; set; }
  public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }

  protected override void OnModelCreating(ModelBuilder builder)
  {
    builder.Entity<Product>().Property(product => product.Description).HasMaxLength(500).IsRequired(false);
    builder.Entity<Product>().Property(product => product.Name).HasMaxLength(160).IsRequired();
    builder.Entity<Product>().Property(product => product.Code).HasMaxLength(20).IsRequired();
  }
}