using ASP_app.Business;
using ASP_app.Models.Types;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASP_app.Api;

[ApiController]
[Authorize]
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