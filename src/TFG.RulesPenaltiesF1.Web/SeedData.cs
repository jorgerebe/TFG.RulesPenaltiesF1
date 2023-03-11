using TFG.RulesPenaltiesF1.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using TFG.RulesPenaltiesF1.Core.Entities;
using TFG.RulesPenaltiesF1.Core.Entities.Penalties;
using TFG.RulesPenaltiesF1.Core.Entities.RegulationAggregate;

namespace TFG.RulesPenaltiesF1.Web
{
   public static class SeedData
   {
      /*ARTICLES*/
      public static readonly Article article1 = new ("A speed limit of 80km/h will be imposed in the pit lane during the whole Competition.\nHowever, this limit may be amended by the Race Director following a recommendation\nfrom the Safety Delegate.");
      public static readonly Article subarticle1 = new ("Any Competitor whose driver exceeds the limit during any practice session will be\nfined €100 for each km/h above the limit, up to a maximum of €1000.");
      public static readonly Article subarticle2 = new ("During a sprint session or the race, the stewards may impose any of the penalties\nunder Article 54.3a), 54.3b), 54.3c) or 54.3d) on any driver who exceeds the limit.");

      /*PENALTIES*/
      public static readonly PenaltyType DQ = new PenaltyType("Disqualification", "Driver disqualified of the race");
      public static readonly PenaltyType TP = new PenaltyType("Time Penalty", "Time Penalty");
      public static readonly PenaltyType GP = new PenaltyType("Drop Grid Positions", "Time Penalty");
      public static readonly PenaltyType DT = new PenaltyType("Drive-Through", "Drive-Through");
      public static readonly PenaltyType StopAndGo = new PenaltyType("Stop And Go", "Stop And Go");
      public static readonly PenaltyType Reprimand = new PenaltyType("Reprimand", "Reprimand");
      public static readonly PenaltyType Fine = new PenaltyType("Fine", "The competitor must pay a fine");

      public static readonly TimePenalty tp_5 = new TimePenalty(TP, 5);
      public static readonly TimePenalty tp_10 = new TimePenalty(TP, 10);
      public static readonly DriveThrough dt = new DriveThrough(DT, 20);
      public static readonly StopAndGo sag = new StopAndGo(StopAndGo, 10, 20);
      public static readonly Reprimand nodrivingReprimand = new Reprimand(Reprimand, false);
      public static readonly Reprimand drivingReprimand = new Reprimand(Reprimand, true);
      public static readonly DropGridPositions dropGridPositions3 = new DropGridPositions(GP, 3);
      public static readonly DropGridPositions dropGridPositions5 = new DropGridPositions(GP, 5);
      public static readonly DropGridPositions dropGridPositions10 = new DropGridPositions(GP, 10);
      public static readonly Disqualification dq = new Disqualification(DQ, false);
      public static readonly Disqualification suspensionNextCompetition = new Disqualification(DQ, true);
      public static readonly Fine fine = new Fine(Fine);

      /*REGULATIONS*/

      public static readonly Regulation regulation = new Regulation(2);

      public static void Initialize(IServiceProvider serviceProvider)
      {
         using var dbContext = new RulesPenaltiesF1DbContext(
             serviceProvider.GetRequiredService<DbContextOptions<RulesPenaltiesF1DbContext>>(), null);
         // Check if DB has already been seeded before populating

         if (dbContext.Article.Any())
         {
            return;
         }

         PopulateTestData(dbContext);
      }
      public static void PopulateTestData(RulesPenaltiesF1DbContext dbContext)
      {
         /* Previous */

         article1.AddSubArticle(subarticle1);
         article1.AddSubArticle(subarticle2);

         regulation.AddArticle(article1);

         /*Remove every item from then DB*/

         foreach (var item in dbContext.Article)
         {
            dbContext.Remove(item);
         }

         foreach(var item in dbContext.Penalty)
         {
            dbContext.Remove(item);
         }

         foreach(var item in dbContext.PenaltyType)
         {
            dbContext.Remove(item);
         }

         // Save changes

         dbContext.SaveChanges();

         // Populate

         /*Articles*/
         dbContext.Article.Add(article1);

         /*Penalty Types*/
         dbContext.PenaltyType.Add(DQ);
         dbContext.PenaltyType.Add(TP);
         dbContext.PenaltyType.Add(GP);
         dbContext.PenaltyType.Add(DT);
         dbContext.PenaltyType.Add(StopAndGo);
         dbContext.PenaltyType.Add(Reprimand);
         dbContext.PenaltyType.Add(Fine);

         /*Penalties*/

         dbContext.Penalty.Add(tp_5);
         dbContext.Penalty.Add(tp_10);
         dbContext.Penalty.Add(dt);
         dbContext.Penalty.Add(sag);
         dbContext.Penalty.Add(nodrivingReprimand);
         dbContext.Penalty.Add(drivingReprimand);
         dbContext.Penalty.Add(dropGridPositions3);
         dbContext.Penalty.Add(dropGridPositions5);
         dbContext.Penalty.Add(dropGridPositions10);
         dbContext.Penalty.Add(dq);
         dbContext.Penalty.Add(suspensionNextCompetition);
         dbContext.Penalty.Add(tp_10);
         dbContext.Penalty.Add(fine);

         /*Regulations*/
         dbContext.Regulation.Add(regulation);


         // Save again

         dbContext.SaveChanges();
      }
   }
}
