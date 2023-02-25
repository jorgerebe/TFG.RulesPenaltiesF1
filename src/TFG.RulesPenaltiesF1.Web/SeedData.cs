using TFG.RulesPenaltiesF1.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using TFG.RulesPenaltiesF1.Core.Entities;

namespace TFG.RulesPenaltiesF1.Web
{
   public static class SeedData
   {

      public static readonly Article article1 = new Article("A speed limit of 80km/h will be imposed in the pit lane during the whole Competition.\nHowever, this limit may be amended by the Race Director following a recommendation\nfrom the Safety Delegate.");
      public static readonly Article subarticle1 = new Article("Any Competitor whose driver exceeds the limit during any practice session will be\nfined €100 for each km/h above the limit, up to a maximum of €1000.");
      public static readonly Article subarticle2 = new Article("During a sprint session or the race, the stewards may impose any of the penalties\nunder Article 54.3a), 54.3b), 54.3c) or 54.3d) on any driver who exceeds the limit.");

      public static void Initialize(IServiceProvider serviceProvider)
      {
         using (var dbContext = new RulesPenaltiesF1DbContext(
             serviceProvider.GetRequiredService<DbContextOptions<RulesPenaltiesF1DbContext>>(), null))
         {
            // Check if DB has already been seeded before populating

            if(dbContext.Article.Any())
            {
               return;
            }

            PopulateTestData(dbContext);
         }
      }
      public static void PopulateTestData(RulesPenaltiesF1DbContext dbContext)
      {
         article1.AddSubArticle(subarticle1);
         article1.AddSubArticle(subarticle2);

         /*Remove every item from then DB*/

         foreach (var item in dbContext.Article)
         {
            dbContext.Remove(item);
         }

         // Save changes

         dbContext.SaveChanges();

         // Populate

         dbContext.Article.Add(article1);

         // Save again

         dbContext.SaveChanges();
      }
   }
}
