using ASP_app.Business;
using ASP_app.Business.Types;
using ASP_app.Models.Types;

namespace ASP_app.Api.Queries;

public class BlogQuery
{
  public async Task<IEnumerable<BlogData>> GetBlogs(
    [Service] BlogService blogService,
    BlogFilter? filter
  ) => await blogService.List(filter ?? new BlogFilter());
}