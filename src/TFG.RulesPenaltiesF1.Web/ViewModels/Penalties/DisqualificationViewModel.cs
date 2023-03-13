namespace TFG.RulesPenaltiesF1.Web.ViewModels.Penalties;

public class DisqualificationViewModel : PenaltyViewModel
{
   public bool NextCompetition { get; set; }

   public override string ToString()
   {
      if (NextCompetition)
      {
         return "The driver is suspended from the next Competition";
      }
      else
      {
         return "The driver is disqualified from the results";
      }
   }
}
