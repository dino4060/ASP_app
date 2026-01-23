using ASP_app.Models;
using ASP_app.Services;
using Microsoft.AspNetCore.Mvc;

namespace ASP_app.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BlogsController(BlogService blogService) : ControllerBase
{
  [HttpGet]
  public IEnumerable<Blog> Get([FromQuery] string? author)
  {
    return blogService.GetBlogs(author);
  }
}