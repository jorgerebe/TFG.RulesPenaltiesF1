using TFG.RulesPenaltiesF1.Core.Entities;

namespace TFG.RulesPenaltiesF1.Core.Interfaces.Repositories;

public interface ISeasonRepository : IRepository<Season>
{
	public Task<Season?> GetSeasonByYear(int year);
	public Task<Season?> GetSeasonById(int id);
	public Task<Season?> GetLatestSeason();
	public Task<Season?> GetCurrentSeason();
	public Task<Season> AddSeason(Season season);
	public Task<Season?> GetSeasonByCompetitonAndCompetitor(int competitionId, int competitorId);
}
