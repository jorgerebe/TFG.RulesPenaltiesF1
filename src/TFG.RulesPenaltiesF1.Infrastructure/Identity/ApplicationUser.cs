using Microsoft.AspNetCore.Identity;
using TFG.RulesPenaltiesF1.Core.Entities.Users;

namespace TFG.RulesPenaltiesF1.Infrastructure.Identity;
public class ApplicationUser : IdentityUser, IUser
{
   public string FullName { get; set; } = string.Empty;
   public string Role { get; set; } = string.Empty;
}
