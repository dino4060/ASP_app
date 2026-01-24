using Microsoft.EntityFrameworkCore;
using ASP_app.Models;
using static ASP_app.Database.AppDbSeeder;

namespace ASP_app.Database;

public class AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration config) : DbContext(options)
{
  public DbSet<Blog> Blogs { get; set; }
  public DbSet<Comment> Comments { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder builder)
  {
    if (builder.IsConfigured)
      return;

    var connectionString = config.GetConnectionString("Database");

    if (string.IsNullOrEmpty(connectionString))
      throw new InvalidOperationException("ConnectionStrings.Database is required in appsettings.json");

    builder.UseSqlServer(connectionString);
  }

  protected override void OnModelCreating(ModelBuilder builder)
  {
    base.OnModelCreating(builder);

    var blogs = GenerateBlogs();
    var comments = GenerateComments(blogs);

    builder.Entity<Blog>().HasData(blogs);
    builder.Entity<Comment>().HasData(comments);
  }
}