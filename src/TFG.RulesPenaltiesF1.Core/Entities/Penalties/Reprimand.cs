namespace TFG.RulesPenaltiesF1.Core.Entities.Penalties;
public class Reprimand : Penalty
{
   public bool? DrivingReprimand { get; set; }

   protected Reprimand() { }

   public Reprimand(PenaltyType penaltyType, bool? drivingReprimand) : base(penaltyType)
   {
      DrivingReprimand = drivingReprimand;
   }
}
