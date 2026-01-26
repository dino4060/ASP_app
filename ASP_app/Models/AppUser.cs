using Microsoft.AspNetCore.Identity;

namespace ASP_app.Models;

// IdentityUser đã có sẵn Id, Email, PasswordHash, v.v.
public class AppUser : IdentityUser
{
  // Bạn có thể thêm các property Enterprise ở đây
  public string? FullName { get; set; }
  public DateTime CreatedAt { get; set; }
}