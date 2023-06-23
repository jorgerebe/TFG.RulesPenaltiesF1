using TFG.RulesPenaltiesF1.Core.Entities;

namespace TFG.RulesPenaltiesF1.Core.Interfaces.Repositories;

public interface IDriverRepository : IRepository<Driver>
{
	Task<List<Driver>> GetAllDrivers();
	Task<Driver?> GetDriverById(int id);
	Task<Driver?> GetDriverByName(string name);
	Task UpdateTeam(Driver driver);
	Task<List<Driver>> GetDriversInCompetitorThatCanCompete(int competitorId, int competitionId);
	Task<Driver?> GetDriverByParticipationId(int participationId);
	Task<List<Driver>> GetDriversWithTwelvePointsAndNoPenaltyLastCompetition(int competitionId);
	Task<List<Driver>> GetDriversWithPenaltyPointsLessThanTwelve();
}
