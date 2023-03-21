using Microsoft.AspNetCore.Identity;
using TFG.RulesPenaltiesF1.Core.Entities.Users;
using TFG.RulesPenaltiesF1.Infrastructure.Identity;

namespace TFG.RulesPenaltiesF1.Web;

public static class SeedDataIdentity
{
   public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
   {
      // Seed roles
      foreach (UserRole role in Enum.GetValues(typeof(UserRole)))
      {
         if (!await roleManager.RoleExistsAsync(role.ToString()))
         {
            await roleManager.CreateAsync(new IdentityRole(role.ToString()));
         }
      }
   }
}

