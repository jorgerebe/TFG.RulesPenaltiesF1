using AcceptanceTests.Drivers;
using AcceptanceTests.Drivers.PageDrivers;
using AcceptanceTests.Hooks;
using AcceptanceTests.PageObjects;
using AcceptanceTests.StepDefinitions;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SpecFlow.Autofac;
using SpecFlow.Autofac.SpecFlowPlugin;
using TFG.RulesPenaltiesF1.Infrastructure.Data;
using TFG.RulesPenaltiesF1.Infrastructure.Identity;

namespace AcceptanceTests.Support;
public static class ScenarioDependencies
{

   [GlobalDependencies]
   public static void RegisterGlobalDependencies(ContainerBuilder builder)
   {
      builder.RegisterType<DbHooks>().SingleInstance();
      builder.RegisterType<LoginHooks>().SingleInstance();

      builder.RegisterType<WebServerDriver>()
            .InstancePerLifetimeScope();

      builder.Register(c => new DbContextOptionsBuilder<RulesPenaltiesF1DbContext>()
             .UseSqlServer("Data Source=MSI\\SQLEXPRESS;Database=RulesPenaltiesF1Testing;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
             .Options)
             .As<DbContextOptions<RulesPenaltiesF1DbContext>>()
             .SingleInstance();

      builder.RegisterType<RulesPenaltiesF1DbContext>()
            .InstancePerDependency();

		ConfigureIdentity(builder);

   }

	private static void ConfigureIdentity(ContainerBuilder builder)
	{
		builder.RegisterType<RulesPenaltiesF1DbContext>().As<DbContext>()
				.InstancePerLifetimeScope();

		builder.RegisterType<UserStore<ApplicationUser>>().As<IUserStore<ApplicationUser>>().InstancePerLifetimeScope();

		builder.Register(c =>
		{
			var options = new IdentityOptions();
			// Configure IdentityOptions if needed
			return Options.Create(options);
		}).As<IOptions<IdentityOptions>>().SingleInstance();

		builder.RegisterType<PasswordHasher<ApplicationUser>>().As<IPasswordHasher<ApplicationUser>>().InstancePerLifetimeScope();
		builder.RegisterType<UpperInvariantLookupNormalizer>().As<ILookupNormalizer>().InstancePerLifetimeScope();
		builder.RegisterType<IdentityErrorDescriber>().InstancePerLifetimeScope();

		builder.Register(c => c.Resolve<IOptions<IdentityOptions>>().Value).As<IdentityOptions>().InstancePerLifetimeScope();

		builder.Register(c => new AutofacServiceProvider((ILifetimeScope)c.Resolve<IComponentContext>())).As<IServiceProvider>().InstancePerLifetimeScope();

		builder.RegisterType<LoggerFactory>().As<ILoggerFactory>().InstancePerLifetimeScope();

		builder.RegisterGeneric(typeof(Logger<>)).As(typeof(ILogger<>)).InstancePerDependency();

		builder.RegisterType<RoleStore<IdentityRole>>().As<IRoleStore<IdentityRole>>().InstancePerDependency();

		builder.RegisterType<UserManager<ApplicationUser>>()
				.InstancePerDependency();
		builder.RegisterType<RoleManager<IdentityRole>>()
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

      builder.RegisterType<LoginPageObjectModel>().InstancePerLifetimeScope();
      builder.RegisterType<LoginPageDriver>().InstancePerLifetimeScope();

      builder.RegisterType<HomePageObjectModel>().InstancePerLifetimeScope();


      builder.RegisterType<HU01_CreateArticlesStepDefinitions>().InstancePerLifetimeScope();
      builder.RegisterType<HU03_RegulationsStepDefinitions>().InstancePerLifetimeScope();
      builder.RegisterType<HU06_LogInStepDefinitions>().InstancePerLifetimeScope();
   }
}
