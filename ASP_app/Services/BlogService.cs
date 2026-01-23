using ASP_app.Models;
using ASP_app.Repositories;

namespace ASP_app.Services;

public class BlogService(BlogRepository blogRepository)
{
  public IEnumerable<Blog> GetBlogs(string? author)
  {
    return blogRepository.GetAll(author);
  }
}