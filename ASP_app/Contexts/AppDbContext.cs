using Microsoft.EntityFrameworkCore;
using ASP_app.Models;

namespace ASP_app.Contexts;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
  public DbSet<Blog> Blogs { get; set; }
  public DbSet<Comment> Comments { get; set; }
}