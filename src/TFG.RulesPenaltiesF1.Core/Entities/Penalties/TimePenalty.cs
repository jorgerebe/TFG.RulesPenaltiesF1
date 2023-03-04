namespace TFG.RulesPenaltiesF1.Core.Entities.Penalties;
public class TimePenalty : Penalty
{
   public int Seconds { get; set; }
   public TimePenalty(PenaltyType penaltyType, int seconds) : base(penaltyType)
   {
      Seconds = seconds;
   }
}
