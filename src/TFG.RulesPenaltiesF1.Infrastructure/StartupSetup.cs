using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TFG.RulesPenaltiesF1.Infrastructure.Data;
using TFG.RulesPenaltiesF1.Infrastructure.Migrations;

namespace TFG.RulesPenaltiesF1.Infrastructure
{
   public static class StartupSetup
   {
      public static void AddDbContext(this IServiceCollection services, string connectionString, bool testing)
      {
         if (testing)
         {
            services.AddDbContext<RulesPenaltiesF1DbContext>(options =>
             options.UseSqlServer(connectionString));

            using (var dbContext = services.BuildServiceProvider().GetService<RulesPenaltiesF1DbContext>()!)
            {
               dbContext.Database.EnsureDeletedAsync().Wait();
               dbContext.Database.EnsureCreatedAsync().Wait();
            }
         }
         else
         {
            services.AddDbContext<RulesPenaltiesF1DbContext>(options =>
             options.UseSqlServer(connectionString));
         }
      }
   }
}
