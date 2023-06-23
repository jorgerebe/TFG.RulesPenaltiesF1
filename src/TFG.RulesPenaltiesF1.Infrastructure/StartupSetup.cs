using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TFG.RulesPenaltiesF1.Infrastructure.Data;

namespace TFG.RulesPenaltiesF1.Infrastructure
	{
	public static class StartupSetup
   {
      public static void AddDbContext(this IServiceCollection services, string connectionString)
      {
         services.AddDbContext<RulesPenaltiesF1DbContext>(options =>
            { options.UseSqlServer(connectionString); options.EnableSensitiveDataLogging(); });
         services.AddScoped<RulesPenaltiesF1DbContext, RulesPenaltiesF1DbContext>();
      }
   }
}
