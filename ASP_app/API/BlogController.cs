using ASP_app.Application;
using ASP_app.Model.Types;
using Microsoft.AspNetCore.Mvc;

namespace ASP_app.API;

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