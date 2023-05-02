using TFG.RulesPenaltiesF1.Core.Entities.CompetitionAggregate;
using TFG.RulesPenaltiesF1.Web.ViewModels;

namespace TFG.RulesPenaltiesF1.Web.Interfaces;

public interface ICompetitionViewModelService
{
	Task<CompetitionViewModel?> GetByIdAsync(int id);
	Task<bool> CanStartCompetition(int id);
	Competition? MapViewModelToEntity(CompetitionViewModel competition);
	CompetitionViewModel? MapEntityToViewModel(Competition competition);
}
