namespace TFG.RulesPenaltiesF1.Core.Entities.Penalties;
public class Fine : Penalty
{

   protected Fine() { }
   public Fine(PenaltyType penaltyType, bool shown) : base(penaltyType, shown)
   {
   }
}
