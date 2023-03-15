using TFG.RulesPenaltiesF1.Infrastructure.Data;
using TFG.RulesPenaltiesF1.Web;

namespace AcceptanceTests.Hooks;

[Binding]
public class DbHooks
{

   private readonly RulesPenaltiesF1DbContext _dbContext;

   public DbHooks(RulesPenaltiesF1DbContext dbContext)
   {
      _dbContext = dbContext;
   }

   [BeforeScenario(Order =10)]
   public void BeforeScenario()
   {
      _dbContext.Database.EnsureDeletedAsync().Wait();
      _dbContext.Database.EnsureCreatedAsync().Wait();
   }

   [AfterScenario(Order =10)]
   public void AfterScenario()
   {
   }

   [Scope(Feature = "HU03-Regulations")]
   [BeforeScenario(Order =15)]
   public void PopulateTestDataRegulations()
   {
      SeedData.PopulateArticles(_dbContext);
      SeedData.PopulatePenalties(_dbContext);

      _dbContext.SaveChanges();
   }
}
