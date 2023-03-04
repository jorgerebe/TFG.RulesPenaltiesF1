namespace TFG.RulesPenaltiesF1.Core.Entities.Penalties;
public class DriveThrough : Penalty
{
   public int ElapsedSeconds { get; set; }
   public DriveThrough(PenaltyType penaltyType, int elapsedSeconds) : base(penaltyType)
   {
      ElapsedSeconds = elapsedSeconds;
   }
}
