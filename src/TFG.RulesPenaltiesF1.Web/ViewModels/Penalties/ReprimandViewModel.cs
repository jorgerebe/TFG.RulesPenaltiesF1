namespace TFG.RulesPenaltiesF1.Web.ViewModels.Penalties;

public class ReprimandViewModel : PenaltyViewModel
{
   public bool IsDriving { get; set; }

   public override string ToString()
   {
      if(IsDriving)
      {
         return "Driving";
      }
      else
      {
         return "No Driving";
      }
   }
}
