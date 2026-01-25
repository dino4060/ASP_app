using ASP_app.Business;
using ASP_app.Business.Types;
using ASP_app.Models;
using ASP_app.Models.Types;

namespace ASP_app.Api.Queries;

public class BlogQuery
{
  public async Task<List<Blog>> GetBlogs(
    [Service] BlogService blogService,
    BlogFilter? filter
  ) => await blogService.List2(filter ?? new BlogFilter());
}