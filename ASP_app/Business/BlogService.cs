using ASP_app.Business.Types;
using ASP_app.Models;
using ASP_app.Models.Repositories;
using ASP_app.Models.Types;
using AutoMapper;

namespace ASP_app.Business;

public class BlogService(BlogRepo blogRepo, IMapper mapper)
{
  public async Task<List<BlogData>> List(BlogFilter filter)
  {
    var blogs = await blogRepo.FindAll(filter);

    return mapper.Map<List<BlogData>>(blogs);
  }
}