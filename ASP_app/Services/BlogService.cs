using ASP_app.Models;
using ASP_app.Repositories;
using ASP_app.Types;

namespace ASP_app.Services;

public class BlogService(BlogRepo blogRepository)
{
  public IEnumerable<Blog> GetBlogs(BlogFilter filter)
  {
    return blogRepository.GetAll(filter);
  }
}