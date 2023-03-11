namespace TFG.RulesPenaltiesF1.Web.ViewModels.Penalties;

public class StopAndGoViewModel : DriveThroughViewModel
{
   public int Seconds { get; set; }

   public override string ToString()
   {
      return Seconds + " seconds";
   }
}
