using TFG.RulesPenaltiesF1.Infrastructure.Data;

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
      _dbContext.Database.EnsureCreatedAsync().Wait();
   }

   [AfterScenario(Order =10)]
   public void AfterScenario()
   {
      _dbContext.Database.EnsureDeletedAsync().Wait();
   }
}
