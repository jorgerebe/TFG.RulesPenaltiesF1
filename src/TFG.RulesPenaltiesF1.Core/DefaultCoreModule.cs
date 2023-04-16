using Autofac;
using TFG.RulesPenaltiesF1.Core.Interfaces.Services;
using TFG.RulesPenaltiesF1.Core.Services;

namespace TFG.RulesPenaltiesF1.Core
{
   public class DefaultCoreModule : Module
   {
      protected override void Load(ContainerBuilder builder)
      {
         builder.RegisterType<ArticleService>()
            .As<IArticleService>().InstancePerLifetimeScope();

         builder.RegisterType<RegulationService>()
            .As<IRegulationService>().InstancePerLifetimeScope();

         builder.RegisterType<CircuitService>()
            .As<ICircuitService>().InstancePerLifetimeScope();

         builder.RegisterType<CompetitorService>()
            .As<ICompetitorService>().InstancePerLifetimeScope();

         builder.RegisterType<SeasonService>()
            .As<ISeasonService>().InstancePerLifetimeScope();
      }
   }
}
