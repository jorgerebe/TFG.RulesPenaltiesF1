using TFG.RulesPenaltiesF1.Web.Interfaces;
using TFG.RulesPenaltiesF1.Web.Services;

namespace TFG.RulesPenaltiesF1.Web.Configuration;

public static class ConfigureWebServices
{
   public static IServiceCollection AddWebServices(this IServiceCollection services, IConfiguration configuration)
   {

      services.AddScoped<IArticleViewModelService, ArticleViewModelService>();

      return services;
   }
}
