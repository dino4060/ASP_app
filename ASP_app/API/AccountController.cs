using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ASP_app.Business;
using ASP_app.Business.Types;

namespace ASP_app.Api;

[ApiController]
[Route("api/[controller]")]
public class AccountController(AccountService accountService) : ControllerBase
{
  [HttpPost("register")]
  public async Task<ActionResult<AuthResult>> Register([FromBody] RegisterDto dto)
  {
    var result = await accountService.Register(dto);
    if (!result.Success) return BadRequest(result);
    return Ok(result);
  }

  [HttpPost("login")]
  public async Task<ActionResult<AuthResult>> Login([FromBody] LoginDto dto)
  {
    var result = await accountService.Login(dto);
    if (!result.Success) return Unauthorized(result);
    return Ok(result);
  }

  [Authorize]
  [HttpPost("logout")]
  public IActionResult Logout()
  {
    // Với JWT, Logout chủ yếu diễn ra ở Client (xóa Token). 
    // Endpoint này trả về 200 OK để Client thực hiện xóa logic.
    return Ok(new { message = "Logged out successfully" });
  }

  [Authorize]
  [HttpGet("me")]
  public async Task<ActionResult<UserProfile>> GetMe()
  {
    // 'User' là property có sẵn của ControllerBase, kiểu ClaimsPrincipal
    var profile = await accountService.GetProfile(User);

    if (profile == null) return NotFound();
    return Ok(profile);
  }
}