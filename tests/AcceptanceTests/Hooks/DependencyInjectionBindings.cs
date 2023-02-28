using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoDi;
using Microsoft.EntityFrameworkCore;
using TFG.RulesPenaltiesF1.Infrastructure.Data;

namespace AcceptanceTests.Hooks;
[Binding]
public class DependencyInjectionBindings
{
   private readonly IObjectContainer _container;

   public DependencyInjectionBindings(IObjectContainer container)
   {
      _container = container;
   }

   [BeforeScenario]
   public void RegisterDbContext()
   {
      var dbContext = new RulesPenaltiesF1DbContext(new DbContextOptionsBuilder<RulesPenaltiesF1DbContext>().UseSqlServer("Data Source=MSI\\\\SQLEXPRESS;Database=RulesPenaltiesF1Testing;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False\"").Options);
      _container.RegisterInstanceAs<RulesPenaltiesF1DbContext>(dbContext);
   }
}
