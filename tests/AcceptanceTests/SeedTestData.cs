using Microsoft.AspNetCore.Identity;
using TFG.RulesPenaltiesF1.Core.Entities;
using TFG.RulesPenaltiesF1.Core.Entities.Penalties;
using TFG.RulesPenaltiesF1.Core.Entities.Users;
using TFG.RulesPenaltiesF1.Infrastructure.Data;
using TFG.RulesPenaltiesF1.Infrastructure.Identity;

namespace AcceptanceTests;

public class SeedTestData
{
   public static void PopulateArticles(RulesPenaltiesF1DbContext dbContext)
   {
      Article article1 = new("A speed limit of 80km/h will be imposed in the pit lane during the whole Competition.\nHowever, this limit may be amended by the Race Director following a recommendation\nfrom the Safety Delegate.");
      Article subarticle1 = new("Any Competitor whose driver exceeds the limit during any practice session will be\nfined €100 for each km/h above the limit, up to a maximum of €1000.");
      Article subarticle2 = new("During a sprint session or the race, the stewards may impose any of the penalties\nunder Article 54.3a), 54.3b), 54.3c) or 54.3d) on any driver who exceeds the limit.");

      Article article2 = new("Drivers must make every reasonable effort to use the track at all times and may not leave the track without a justifiable reason.");


      article1.AddSubArticle(subarticle1);
      article1.AddSubArticle(subarticle2);

      dbContext.Article.Add(article1);
      dbContext.Article.Add(article2);
   }

   public static void PopulatePenalties(RulesPenaltiesF1DbContext dbContext)
   {
       PenaltyType DQ = new PenaltyType("Disqualification", "Driver disqualified of the race", true, false);
       PenaltyType TP = new PenaltyType("Time Penalty", "Time Penalty", true, false);
       PenaltyType GP = new PenaltyType("Drop Grid Positions", "Drop Grid Position", true, false);
       PenaltyType DT = new PenaltyType("Drive-Through", "Drive-Through", true, false);
       PenaltyType StopAndGo = new PenaltyType("Stop And Go", "Stop And Go", true, false);
       PenaltyType Reprimand = new PenaltyType("Reprimand", "Reprimand", false, false);
       PenaltyType Fine = new PenaltyType("Fine", "The competitor must pay a fine", false, true);

       TimePenalty tp_5 = new TimePenalty(TP, 5);
       TimePenalty tp_10 = new TimePenalty(TP, 10);
       DriveThrough dt = new DriveThrough(DT, 20);
       StopAndGo sag = new StopAndGo(StopAndGo, 10, 20);
       Reprimand nodrivingReprimand = new Reprimand(Reprimand, false);
       Reprimand drivingReprimand = new Reprimand(Reprimand, true);
       DropGridPositions dropGridPositions3 = new DropGridPositions(GP, 3);
       DropGridPositions dropGridPositions5 = new DropGridPositions(GP, 5);
       DropGridPositions dropGridPositions10 = new DropGridPositions(GP, 10);
       Disqualification dq = new Disqualification(DQ, false);
       Disqualification suspensionNextCompetition = new Disqualification(DQ, true);
       Fine fine = new Fine(Fine);

      /*Penalty Types*/
      dbContext.PenaltyType.Add(DQ);
      dbContext.PenaltyType.Add(TP);
      dbContext.PenaltyType.Add(GP);
      dbContext.PenaltyType.Add(DT);
      dbContext.PenaltyType.Add(StopAndGo);
      dbContext.PenaltyType.Add(Reprimand);
      dbContext.PenaltyType.Add(Fine);

      /*Penalties*/

      dbContext.Penalty.Add(tp_5);
      dbContext.Penalty.Add(tp_10);
      dbContext.Penalty.Add(dt);
      dbContext.Penalty.Add(sag);
      dbContext.Penalty.Add(nodrivingReprimand);
      dbContext.Penalty.Add(drivingReprimand);
      dbContext.Penalty.Add(dropGridPositions3);
      dbContext.Penalty.Add(dropGridPositions5);
      dbContext.Penalty.Add(dropGridPositions10);
      dbContext.Penalty.Add(dq);
      dbContext.Penalty.Add(suspensionNextCompetition);
      dbContext.Penalty.Add(tp_10);
      dbContext.Penalty.Add(fine);
   }

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
