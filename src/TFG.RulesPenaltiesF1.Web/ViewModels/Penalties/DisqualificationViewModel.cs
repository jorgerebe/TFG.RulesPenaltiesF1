using TFG.RulesPenaltiesF1.Core.Entities.Penalties;

namespace TFG.RulesPenaltiesF1.Web.ViewModels.Penalties;

public class DisqualificationViewModel : PenaltyViewModel
{
   public DisqualificationTypeEnum? Type { get; set; }

   public override string ToString()
   {
		if (Type!.Equals(DisqualificationTypeEnum.Next))
		{
         return "Suspension: The driver is suspended from the next Competition";
      }
      else if(Type.Equals(DisqualificationTypeEnum.Current))
      {
         return "Disqualification: The driver is disqualified from the results";
      }
		else if(Type.Equals(DisqualificationTypeEnum.LicensePointsLimit))
		{
			return "Suspension for surpasing the limit of License Points in 12 months";
		}
		else
		{
			return string.Empty;
		}
   }
}
