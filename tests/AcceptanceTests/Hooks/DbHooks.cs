﻿using Microsoft.EntityFrameworkCore;
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
}
