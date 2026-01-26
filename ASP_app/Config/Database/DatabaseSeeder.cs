using ASP_app.Models;
using Bogus;
using Microsoft.AspNetCore.Identity;

namespace ASP_app.Config.Database;

public static class DatabaseSeeder
{
  private static readonly Faker _faker = new();
  private static readonly PasswordHasher<AppUser> _hasher = new();

  public static (List<IdentityRole> Roles, List<AppUser> Users, List<IdentityUserRole<string>> UserRoles) GenerateIdentityData()
  {
    Randomizer.Seed = new Random(123456);
    var seedDate = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc);
    const string staticHash = "AQAAAAIAAYagAAAAEOf6Pb8v/8VwLIDv8T6/7UfVvJqR9Z0X5Y6vX5Y6vX";

    // Gán Stamp cố định để tránh EF tạo Guid mới mỗi lần Build
    const string staticStamp = "STATIC_STAMP_123456";

    // 1. Define Roles
    var roles = new List<IdentityRole>
    {
        new() { Id = "r-admin", Name = "Admin", NormalizedName = "ADMIN", ConcurrencyStamp = staticStamp },
        new() { Id = "r-u2", Name = "UserLevel2", NormalizedName = "USERLEVEL2", ConcurrencyStamp = staticStamp },
        new() { Id = "r-u1", Name = "User", NormalizedName = "USER", ConcurrencyStamp = staticStamp }
    };

    // 2. Define Users
    var admin = new AppUser
    {
      Id = "u-admin",
      UserName = "Top1Server",
      NormalizedUserName = "TOP1SERVER",
      Email = "admin@asp.app",
      NormalizedEmail = "ADMIN@ASP.APP",
      EmailConfirmed = true,
      CreatedAt = seedDate,
      PasswordHash = staticHash,
      SecurityStamp = staticStamp, // Quan trọng: Phải tĩnh
      ConcurrencyStamp = staticStamp // Quan trọng: Phải tĩnh
    };

    var host1 = new AppUser
    {
      Id = "u-host1",
      UserName = "Host1",
      NormalizedUserName = "HOST1",
      Email = "host1@asp.app",
      NormalizedEmail = "HOST1@ASP.APP",
      EmailConfirmed = true,
      CreatedAt = seedDate,
      PasswordHash = staticHash,
      SecurityStamp = staticStamp,
      ConcurrencyStamp = staticStamp
    };

    var user1 = new AppUser
    {
      Id = "u-user1",
      UserName = "User1",
      NormalizedUserName = "USER1",
      Email = "user1@asp.app",
      NormalizedEmail = "USER1@ASP.APP",
      EmailConfirmed = true,
      CreatedAt = seedDate,
      PasswordHash = staticHash,
      SecurityStamp = staticStamp,
      ConcurrencyStamp = staticStamp
    };

    var users = new List<AppUser> { admin, host1, user1 };

    // 3. Map Users to Roles
    var userRoles = new List<IdentityUserRole<string>>
    {
        new() { RoleId = "r-admin", UserId = "u-admin" },
        new() { RoleId = "r-u2", UserId = "u-host1" },
        new() { RoleId = "r-u1", UserId = "u-user1" }
    };

    return (roles, users, userRoles);
  }

  public static List<Blog> GenerateBlogs()
  {
    Randomizer.Seed = new Random(123456);
    var Id = 1;

    return new Faker<Blog>("vi")
        .RuleFor(b => b.Id, f => Id++)
        .RuleFor(b => b.Title, f => f.Lorem.Sentence())
        .RuleFor(b => b.Content, f => f.Lorem.Paragraphs(1))
        .RuleFor(b => b.Author, f => f.Name.FullName())
        .RuleFor(b => b.CreatedAt, f => f.Date.Between(new DateTime(2025, 12, 25), new DateTime(2026, 12, 26)))
        .Generate(10);
  }

  public static List<Comment> GenerateComments(List<Blog> blogs)
  {
    Randomizer.Seed = new Random(123456);
    var faker = new Faker();
    var Id = 1;

    return [.. blogs.SelectMany(blog => new Faker<Comment>("vi")
          .RuleFor(c => c.Id, _ => Id++)
          .RuleFor(c => c.User, f => f.Name.FullName())
          .RuleFor(c => c.Content, f => f.Rant.Review())
          .RuleFor(c => c.Rating, f => f.Random.Number(1, 5))
          .RuleFor(c => c.BlogId, _ => blog.Id)
          .Generate(_faker.Random.Number(0, 10)))];
  }
}