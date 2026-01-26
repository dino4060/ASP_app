using ASP_app.Models;

namespace ASP_app.Business.Interfaces;

public interface ITokenService
{
  // Cần truyền thêm roles vào để nhúng vào JWT Claims cho Role-based Auth
  string CreateToken(AppUser user, IList<string> roles);
}