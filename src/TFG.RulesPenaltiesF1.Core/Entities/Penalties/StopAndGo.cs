namespace TFG.RulesPenaltiesF1.Core.Entities.Penalties;
public class StopAndGo : DriveThrough
{
   public int Seconds { get; set; }
   public StopAndGo(PenaltyType penaltyType, int seconds, int elapsedSeconds) : base(penaltyType, elapsedSeconds)
   {
      Seconds = seconds;
      ElapsedSeconds = elapsedSeconds;
   }
}
