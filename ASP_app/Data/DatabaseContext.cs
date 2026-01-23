using Microsoft.EntityFrameworkCore;
using ASP_app.Models;

namespace ASP_app.Data;

public class DatabaseContext(DbContextOptions<DatabaseContext> options) : DbContext(options)
{
  // public DbSet<Blog> Blogs { get; set; }
  // public DbSet<Comment> Comments { get; set; }
}