using Microsoft.AspNetCore.Identity;
using TFG.RulesPenaltiesF1.Core.Entities.Users;

namespace TFG.RulesPenaltiesF1.Infrastructure.Identity;
public class ApplicationUser : IdentityUser, IUser
{
   string? IUser.Email { get => Email; set => Email = value; }
   public string FullName { get; set; } = string.Empty;
}
