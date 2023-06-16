using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TFG.RulesPenaltiesF1.Infrastructure.Data;
using TFG.RulesPenaltiesF1.Infrastructure.Identity;
using TFG.RulesPenaltiesF1.Web;

namespace AcceptanceTests.Hooks;

[Binding]
public class DbHooks
{
   private readonly RulesPenaltiesF1DbContext _dbContext;
   private readonly UserManager<ApplicationUser> _userManager;
   private readonly RoleManager<IdentityRole> _roleManager;

   public DbHooks(RulesPenaltiesF1DbContext dbContext, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
   {
      _dbContext = dbContext;
		_userManager = userManager;
		_roleManager = roleManager;
	}

   [BeforeScenario(Order =10)]
   public void BeforeScenario()
   {
      _dbContext.Database.EnsureDeleted();
      _dbContext.Database.EnsureCreated();
   }

   [AfterScenario(Order =5)]
   public void AfterScenario()
   {
      _dbContext.Database.EnsureDeleted();
   }

   [Scope(Feature = "HU03-Regulations")]
   [BeforeScenario(Order =15)]
   public void PopulateTestDataRegulations()
   {
      SeedTestData.PopulateArticles(_dbContext);
      SeedTestData.PopulatePenalties(_dbContext);
      _dbContext.SaveChanges();
   }

   [BeforeScenario(Order =20)]
   public async Task PopulateTestIdentity()
   {
      await SeedTestData.SeedAsync(_userManager, _roleManager);
   }
}
