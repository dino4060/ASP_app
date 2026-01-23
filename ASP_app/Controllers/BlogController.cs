using ASP_app.Services;
using ASP_app.Types;
using Microsoft.AspNetCore.Mvc;

namespace ASP_app.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BlogsController(BlogService blogService) : ControllerBase
{
  [HttpGet]
  public async Task<ActionResult> Get([FromQuery] BlogFilter filter)
  {
    var result = await blogService.List(filter);
    return Ok(result);
  }
}