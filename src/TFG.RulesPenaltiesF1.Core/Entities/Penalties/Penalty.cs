using TFG.RulesPenaltiesF1.Core.Interfaces;

namespace TFG.RulesPenaltiesF1.Core.Entities.Penalties;
public abstract class Penalty : EntityBase, IAggregateRoot
{
   public int PenaltyTypeId { get; set; }

   public PenaltyType? PenaltyType { get; set; }

   protected Penalty() { }

   public Penalty(PenaltyType penaltyType)
   {
      PenaltyType = penaltyType;
   }
}
