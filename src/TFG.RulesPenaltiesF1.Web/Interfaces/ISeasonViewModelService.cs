using TFG.RulesPenaltiesF1.Web.ViewModels;

namespace TFG.RulesPenaltiesF1.Web.Interfaces;

public interface ISeasonViewModelService
{
   Task<SeasonViewModel?> GetByIdAsync(int id);
}
