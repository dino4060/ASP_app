using ASP_app.Models;
using ASP_app.Types;

namespace ASP_app.Repositories;

public class BlogRepo
{
  private readonly List<Blog> _blogs =
  [
    new(1, "Học .NET 10", "Nhan handsome đang học multi-layers", "Nhẫn", DateTime.Now,
    [
      new("UserA", "Bài viết hay quá!", 5),
      new("UserB", "Rất chi tiết", 4)
    ]),
    new(2, "C# Dev Kit", "Hướng dẫn chuyên nghiệp", "Microsoft", DateTime.Now.AddDays(-1),
    [
      new("UserC", "Hơi khó hiểu đoạn cài đặt", 3)
    ]),
    new(3, "LINQ Thần Chưởng", "Cách filter pro", "Nhẫn", DateTime.Now.AddDays(-2), [])
  ];

  public IEnumerable<Blog> GetAll(BlogFilter filter)
  {
    var query = _blogs.AsEnumerable();

    if (!string.IsNullOrWhiteSpace(filter.Author))
    {
      query = query.Where(b => b.Author.Contains(filter.Author, StringComparison.OrdinalIgnoreCase));
    }

    if (filter.Rating.HasValue)
    {
      query = query.Where(b => b.AverageRating >= filter.Rating.Value);
    }

    return query;
  }
}