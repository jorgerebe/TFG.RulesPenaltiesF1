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

      if (await userManager.FindByEmailAsync("steward@steward.com") == null)
      {
         ApplicationUser user = new ApplicationUser
         {
            FullName = "Nish Shetty",
            UserName = "steward@steward.com",
            Email = "steward@steward.com"
         };

         IdentityResult result = await userManager.CreateAsync(user, "Steward.");

         if (result.Succeeded)
         {
            await userManager.AddToRoleAsync(user, "Steward");
         }
      }

      if (await userManager.FindByEmailAsync("horner@teamprincipal.com") == null)
      {
         ApplicationUser user = new ApplicationUser
         {
            FullName = "Christian Horner",
            UserName = "horner@teamprincipal.com",
            Email = "horner@teamprincipal.com"
         };

         IdentityResult result = await userManager.CreateAsync(user, "Horner.");

         if (result.Succeeded)
         {
            await userManager.AddToRoleAsync(user, "TeamPrincipal");
         }
      }
   }
}

