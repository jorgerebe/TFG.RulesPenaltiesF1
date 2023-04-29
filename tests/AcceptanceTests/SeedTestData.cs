using TFG.RulesPenaltiesF1.Core.Entities;
using TFG.RulesPenaltiesF1.Core.Entities.Penalties;
using TFG.RulesPenaltiesF1.Infrastructure.Data;

namespace AcceptanceTests;

public class SeedTestData
{
   public static void PopulateArticles(RulesPenaltiesF1DbContext dbContext)
   {
      Article article1 = new("A speed limit of 80km/h will be imposed in the pit lane during the whole Competition.\nHowever, this limit may be amended by the Race Director following a recommendation\nfrom the Safety Delegate.");
      Article subarticle1 = new("Any Competitor whose driver exceeds the limit during any practice session will be\nfined €100 for each km/h above the limit, up to a maximum of €1000.");
      Article subarticle2 = new("During a sprint session or the race, the stewards may impose any of the penalties\nunder Article 54.3a), 54.3b), 54.3c) or 54.3d) on any driver who exceeds the limit.");

      Article article2 = new("Drivers must make every reasonable effort to use the track at all times and may not leave the track without a justifiable reason.");


      article1.AddSubArticle(subarticle1);
      article1.AddSubArticle(subarticle2);

      dbContext.Article.Add(article1);
      dbContext.Article.Add(article2);
   }

   public static void PopulatePenalties(RulesPenaltiesF1DbContext dbContext)
   {
       PenaltyType DQ = new PenaltyType("Disqualification", "Driver disqualified of the race");
       PenaltyType TP = new PenaltyType("Time Penalty", "Time Penalty");
       PenaltyType GP = new PenaltyType("Drop Grid Positions", "Drop Grid Position");
       PenaltyType DT = new PenaltyType("Drive-Through", "Drive-Through");
       PenaltyType StopAndGo = new PenaltyType("Stop And Go", "Stop And Go");
       PenaltyType Reprimand = new PenaltyType("Reprimand", "Reprimand");
       PenaltyType Fine = new PenaltyType("Fine", "The competitor must pay a fine");

       TimePenalty tp_5 = new TimePenalty(TP, 5);
       TimePenalty tp_10 = new TimePenalty(TP, 10);
       DriveThrough dt = new DriveThrough(DT, 20);
       StopAndGo sag = new StopAndGo(StopAndGo, 10, 20);
       Reprimand nodrivingReprimand = new Reprimand(Reprimand, false);
       Reprimand drivingReprimand = new Reprimand(Reprimand, true);
       DropGridPositions dropGridPositions3 = new DropGridPositions(GP, 3);
       DropGridPositions dropGridPositions5 = new DropGridPositions(GP, 5);
       DropGridPositions dropGridPositions10 = new DropGridPositions(GP, 10);
       Disqualification dq = new Disqualification(DQ, false);
       Disqualification suspensionNextCompetition = new Disqualification(DQ, true);
       Fine fine = new Fine(Fine);

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
   }
}
