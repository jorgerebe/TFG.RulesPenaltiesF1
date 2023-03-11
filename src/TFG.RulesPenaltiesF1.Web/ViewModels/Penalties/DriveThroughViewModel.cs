namespace TFG.RulesPenaltiesF1.Web.ViewModels.Penalties;

public class DriveThroughViewModel : PenaltyViewModel
{
   public int ElapsedTime { get; set; }

   public override string ToString()
   {
      return ElapsedTime + " seconds";
   }
}
