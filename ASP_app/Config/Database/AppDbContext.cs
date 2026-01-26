using ASP_app.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using static ASP_app.Config.Database.DatabaseSeeder;

namespace ASP_app.Config.Database;

public class AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration config)
: IdentityDbContext<AppUser>(options)
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

    // Seed Identity Data
    var (roles, users, userRoles) = GenerateIdentityData();
    builder.Entity<IdentityRole>().HasData(roles);
    builder.Entity<AppUser>().HasData(users);
    builder.Entity<IdentityUserRole<string>>().HasData(userRoles);

    // Seed Blog Data
    var blogs = GenerateBlogs();
    builder.Entity<Blog>().HasData(blogs);

    // Seed Comment Data
    var comments = GenerateComments(blogs);
    builder.Entity<Comment>().HasData(comments);
  }
}