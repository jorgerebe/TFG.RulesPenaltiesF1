using TFG.RulesPenaltiesF1.Web.Interfaces;
using TFG.RulesPenaltiesF1.Web.Services;

namespace TFG.RulesPenaltiesF1.Web.Configuration;

public static class ConfigureWebServices
{
   public static IServiceCollection AddWebServices(this IServiceCollection services, IConfiguration configuration)
   {
         
      services.AddScoped<IArticleViewModelService, ArticleViewModelService>();
      services.AddScoped<IPenaltyViewModelService, PenaltyViewModelService>();
      services.AddScoped<IRegulationViewModelService, RegulationViewModelService>();
      services.AddScoped<ICircuitViewModelService, CircuitViewModelService>();
      services.AddScoped<ICompetitorViewModelService, CompetitorViewModelService>();
      services.AddScoped<ISeasonViewModelService, SeasonViewModelService>();

      return services;
   }
}
