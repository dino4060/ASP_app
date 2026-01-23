using ASP_app.Models;

namespace ASP_app.Repositories;

public class BlogRepository
{
  private readonly List<Blog> _blogs =
  [
    new(1, "Học .NET 10", "Nhan handsome đang học multi-layers", "Nhẫn", DateTime.Now),
    new(2, "C# Dev Kit", "Hướng dẫn dùng VS Code chuyên nghiệp", "Microsoft", DateTime.Now.AddDays(-1)),
    new(3, "LINQ Thần Chưởng", "Cách filter dữ liệu như pro", "Nhẫn", DateTime.Now.AddDays(-2))
  ];

  public IEnumerable<Blog> GetAll(string? author)
  {
    if (string.IsNullOrWhiteSpace(author))
    {
      return _blogs;
    }

    // LINQ filter theo tác giả (không phân biệt hoa thường)
    return _blogs.Where(b => b.Author.Contains(author, StringComparison.OrdinalIgnoreCase));
  }
}