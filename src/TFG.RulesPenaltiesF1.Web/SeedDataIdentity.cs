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

      await PopulateUsers("steward@steward.com", "Nish Shetty", UserRole.Steward, "Steward.", userManager, roleManager);
      await PopulateUsers("horner@teamprincipal.com", "Christian Horner", UserRole.TeamPrincipal, "Horner.", userManager, roleManager);
      await PopulateUsers("stella@teamprincipal.com", "Andrea Stella", UserRole.TeamPrincipal, "Stella.", userManager, roleManager);
      await PopulateUsers("wolff@teamprincipal.com", "Toto Wolff", UserRole.TeamPrincipal, "Wolff.", userManager, roleManager);
      await PopulateUsers("vasseur@teamprincipal.com", "Frédéric Vasseur", UserRole.TeamPrincipal, "Vasseur.", userManager, roleManager);
      await PopulateUsers("szafnauer@teamprincipal.com", "Otmar Szafnauer", UserRole.TeamPrincipal, "Szafnauer.", userManager, roleManager);
   }

   private static async Task PopulateUsers(string email, string name, UserRole role, string password, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
   {
      if (await userManager.FindByEmailAsync(email) == null)
      {
         ApplicationUser user = new ApplicationUser
         {
            FullName = name,
            UserName = email,
            Email = email
         };

         IdentityResult result = await userManager.CreateAsync(user, password);

         if (result.Succeeded)
         {
            await userManager.AddToRoleAsync(user, role.ToString());
         }
      }
   }
}

