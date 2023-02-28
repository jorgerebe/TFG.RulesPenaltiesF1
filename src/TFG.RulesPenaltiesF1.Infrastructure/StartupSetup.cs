using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TFG.RulesPenaltiesF1.Infrastructure.Data;
using TFG.RulesPenaltiesF1.Infrastructure.Migrations;

namespace TFG.RulesPenaltiesF1.Infrastructure
{
   public static class StartupSetup
   {
      public static void AddDbContext(this IServiceCollection services, string connectionString)
      {
         services.AddDbContext<RulesPenaltiesF1DbContext>(options =>
            options.UseSqlServer(connectionString));
         services.AddScoped<RulesPenaltiesF1DbContext, RulesPenaltiesF1DbContext>();
      }
   }
}
