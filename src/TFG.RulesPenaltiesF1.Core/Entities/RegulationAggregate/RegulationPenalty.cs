using TFG.RulesPenaltiesF1.Core.Entities.Penalties;

namespace TFG.RulesPenaltiesF1.Core.Entities.RegulationAggregate;
public class RegulationPenalty
{
   public int RegulationId { get; private set; }
   public Regulation? Regulation { get; private set; }

   public int PenaltyId { get; private set; }
   public Penalty? Penalty { get; private set; }

   public RegulationPenalty(int regulationId, int penaltyId)
   {
      RegulationId = regulationId;
      PenaltyId = penaltyId;
   }

   public RegulationPenalty(Regulation regulation, Penalty penalty)
   {
      if (regulation is null || penalty is null)
      {
         throw new ArgumentException("There must be a regulation and an article");
      }

      Regulation = regulation;
      RegulationId = regulation.Id;
      Penalty = penalty;
      PenaltyId = penalty.Id;
   }
}
