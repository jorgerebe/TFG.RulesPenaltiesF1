using TFG.RulesPenaltiesF1.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace TFG.RulesPenaltiesF1.Web
{
   public static class SeedData
   {

      public static void Initialize(IServiceProvider serviceProvider)
      {
         using (var dbContext = new RulesPenaltiesF1DbContext(
             serviceProvider.GetRequiredService<DbContextOptions<RulesPenaltiesF1DbContext>>(), null))
         {
            // Check if DB has already been seeded before populating

            PopulateTestData(dbContext);


         }
      }
      public static void PopulateTestData(RulesPenaltiesF1DbContext dbContext)
      {
         /*Remove every item from then DB*/
         // Save changes
         // Populate
         // Save again
      }
   }
}
