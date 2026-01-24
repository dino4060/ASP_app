using ASP_app.Models;
using Bogus;

namespace ASP_app.Database;

public class AppDbSeeder
{
  private static readonly Faker _faker = new();

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