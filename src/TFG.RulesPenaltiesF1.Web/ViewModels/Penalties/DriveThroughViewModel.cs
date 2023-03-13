namespace TFG.RulesPenaltiesF1.Web.ViewModels.Penalties;

public class DriveThroughViewModel : PenaltyViewModel
{
   public int ElapsedTime { get; set; }

   public override string ToString()
   {
      return base.ToString() + ": " + ElapsedTime + " seconds (if not possible to comply, " + (ElapsedTime) + " seconds will be added at the end)";
   }
}
