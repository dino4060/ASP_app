using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace ASP_app.Api;

[AllowAnonymous] // Bypass tất cả auth/jwt/role cho Controller này
[ApiController]
[Route("api/public")]
public class PublicController : ControllerBase
{
  [HttpGet("info")] // URL: /api/public/info
  public IActionResult GetInfo() => Ok(new { message = "This is public data" });

  [HttpGet("status/{id}")] // URL: /api/public/status/1
  public IActionResult GetStatus(int id) => Ok(new { id, status = "Active" });
}