using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace ASP_app.Api;

[AllowAnonymous]
[ApiController]
[Route("public")]
public class RootPublicController : ControllerBase
{
  [HttpGet("{**slug}")] // Catch-all cho bất kỳ sub-path nào sau /public/
  public IActionResult GetPublicAny(string slug)
  {
    return Ok(new { path = slug, access = "Free" });
  }
}