namespace TFG.RulesPenaltiesF1.Web.ViewModels.Penalties;

public class ReprimandViewModel : PenaltyViewModel
{
   public bool IsDriving { get; set; }

   public override string ToString()
   {
      string output = base.ToString() +" - ";

      if(IsDriving)
      {
         output += "Driving";
      }
      else
      {
         output += "No Driving";
      }

      return output;
   }
}
