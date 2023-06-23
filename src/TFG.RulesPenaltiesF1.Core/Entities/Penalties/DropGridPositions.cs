namespace TFG.RulesPenaltiesF1.Core.Entities.Penalties;
public class DropGridPositions : Penalty
{
   public int Positions { get; set; }

   protected DropGridPositions() { }

   public DropGridPositions(PenaltyType penaltyType, int positions, bool shown) : base(penaltyType, shown)
   {
      Positions = positions;
   }
}
