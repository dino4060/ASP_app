using ASP_app.Models;
using ASP_app.Models.Repositories;
using ASP_app.Model.Types;

namespace ASP_app.Application;

public class BlogService(BlogRepo blogRepository)
{
  public Task<IEnumerable<Blog>> List(BlogFilter filter)
  {
    return blogRepository.FindAll(filter);
  }
}