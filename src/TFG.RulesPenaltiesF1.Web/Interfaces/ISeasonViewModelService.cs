using TFG.RulesPenaltiesF1.Core.Entities;
using TFG.RulesPenaltiesF1.Web.ViewModels;

namespace TFG.RulesPenaltiesF1.Web.Interfaces;

public interface ISeasonViewModelService
{
	Task<List<SeasonViewModel>> GetSeasonsAsync();
   Task<SeasonViewModel?> GetByIdAsync(int id);
	Task<bool> ExistsSeasonInYear(int year);

	Task<bool> CompetitorPresentInSeasonOfCompetition(int competitionId, int competitorId);
	Task<bool> CanCreateAnotherSeason();
}
