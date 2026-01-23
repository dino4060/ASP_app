using ASP_app.Models;
using ASP_app.Services;
using ASP_app.Types;
using Microsoft.AspNetCore.Mvc;

namespace ASP_app.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BlogsController(BlogService blogService) : ControllerBase
{
  [HttpGet]
  public IEnumerable<Blog> Get([FromQuery] BlogFilter filter)
  {
    return blogService.GetBlogs(filter);
  }
}