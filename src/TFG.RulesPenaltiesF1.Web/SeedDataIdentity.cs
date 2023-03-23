using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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

      if (await userManager.FindByEmailAsync("admin@example.com") == null)
      {
         ApplicationUser user = new ApplicationUser
         {
            UserName = "steward@steward.com",
            Email = "steward@steward.com"
         };

         IdentityResult result = await userManager.CreateAsync(user, "Steward.");

         if (result.Succeeded)
         {
            await userManager.AddToRoleAsync(user, "Steward");
         }
      }
   }
}

