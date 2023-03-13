namespace TFG.RulesPenaltiesF1.Web.ViewModels.Penalties;

public class StopAndGoViewModel : DriveThroughViewModel
{
   public int Seconds { get; set; }

   public override string ToString()
   {
      return Name + ": " + Description + ": " + Seconds + " seconds (if not possible to comply, " + (ElapsedTime+Seconds) + " seconds will be added at the end)";
   }
}
