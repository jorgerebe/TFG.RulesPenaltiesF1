using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcceptanceTests.Drivers;
using AcceptanceTests.Hooks;
using AcceptanceTests.PageObjects;
using AcceptanceTests.StepDefinitions;
using Autofac;
using Microsoft.EntityFrameworkCore;
using SpecFlow.Autofac;
using SpecFlow.Autofac.SpecFlowPlugin;
using TFG.RulesPenaltiesF1.Infrastructure.Data;

namespace AcceptanceTests.Support;
public static class ScenarioDependencies
{
   [GlobalDependencies]
   public static void RegisterGlobalDependencies(ContainerBuilder builder)
   {
      builder.RegisterType<DbHooks>().SingleInstance();

      builder.RegisterType<WebServerDriver>()
            .SingleInstance();

      builder.Register(c => new DbContextOptionsBuilder<RulesPenaltiesF1DbContext>()
             .UseSqlServer("Data Source=MSI\\SQLEXPRESS;Database=RulesPenaltiesF1Testing;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
             .Options)
             .As<DbContextOptions<RulesPenaltiesF1DbContext>>()
             .SingleInstance();

      builder.RegisterType<RulesPenaltiesF1DbContext>()
            .InstancePerDependency();
   }


   [ScenarioDependencies]
   public static void RegisterDependencies(ContainerBuilder builder)
   {
      builder.RegisterType<BrowserDriver>().InstancePerLifetimeScope();
      builder.RegisterType<ArticlePageDriver>().InstancePerLifetimeScope();
      builder.RegisterType<ArticlePageObjectModel>().InstancePerLifetimeScope();
      builder.RegisterType<RegulationPageDriver>().InstancePerLifetimeScope();
      builder.RegisterType<RegulationPageObjectModel>().InstancePerLifetimeScope();


      builder.RegisterType<HU01_CreateArticlesStepDefinitions>().InstancePerLifetimeScope();
      builder.RegisterType<HU03_RegulationsStepDefinitions>().InstancePerLifetimeScope();
   }
}
