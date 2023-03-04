using TFG.RulesPenaltiesF1.Core.Interfaces;

namespace TFG.RulesPenaltiesF1.Core.Entities.Penalties;
public abstract class Penalty : EntityBase, IAggregateRoot
{
   public PenaltyType PenaltyType { get; set; }

   public Penalty(PenaltyType penaltyType)
   {
      PenaltyType = penaltyType;
   }
}
