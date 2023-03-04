namespace TFG.RulesPenaltiesF1.Core.Entities.Penalties;
public class StopAndGo : Penalty
{
   public DriveThrough DriveThrough { get; set; }
   public int Seconds { get; set; }

   public StopAndGo(PenaltyType penaltyType, DriveThrough driveThrough, int seconds) : base(penaltyType)
   {
      DriveThrough = driveThrough;
      Seconds = seconds;
   }
}
