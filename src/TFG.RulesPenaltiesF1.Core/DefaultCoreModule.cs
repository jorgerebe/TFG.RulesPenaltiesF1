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
      }
   }
}
