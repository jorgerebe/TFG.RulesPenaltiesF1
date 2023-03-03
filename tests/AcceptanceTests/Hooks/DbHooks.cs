using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoDi;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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
      _dbContext.Database.EnsureDeletedAsync().Wait();
      _dbContext.Database.EnsureCreatedAsync().Wait();
   }

   [AfterScenario(Order =10)]
   public void AfterScenario()
   {
      // Perform any cleanup that requires the _dbContext instance here
   }
}
