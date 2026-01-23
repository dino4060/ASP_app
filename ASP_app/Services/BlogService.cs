using ASP_app.Models;
using ASP_app.Repositories;
using ASP_app.Types;

namespace ASP_app.Services;

public class BlogService(BlogRepo blogRepository)
{
  public Task<IEnumerable<Blog>> List(BlogFilter filter)
  {
    return blogRepository.FindAll(filter);
  }
}