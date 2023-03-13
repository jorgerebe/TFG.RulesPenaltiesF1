using TFG.RulesPenaltiesF1.Web.ViewModels.Penalties;

namespace TFG.RulesPenaltiesF1.Web.Interfaces;

public interface IPenaltyViewModelService
{
   Task<List<PenaltyViewModel>> GetPenaltiesAsync();
}
