using ASP_app.Models;
using ASP_app.Types;
using static ASP_app.Helpers.FilterHelper;

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

  public async Task<IEnumerable<Blog>> FindAll(BlogFilter filter)
  {
    await Task.Delay(50);

    return _blogs.Where(b =>
        IsPassed(filter.Author, () => b.Author.Contains(filter.Author!, StringComparison.OrdinalIgnoreCase)) &&
        IsPassed(filter.Rating, () => b.AverageRating >= filter.Rating!.Value)
    );
  }
}