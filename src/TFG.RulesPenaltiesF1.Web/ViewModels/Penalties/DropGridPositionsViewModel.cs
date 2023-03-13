namespace TFG.RulesPenaltiesF1.Web.ViewModels.Penalties;

public class DropGridPositionsViewModel : PenaltyViewModel
{
   public int Positions { get; set; }

   public override string ToString()
   {
      return base.ToString() + ": " + Positions + " positions";
   }
}
