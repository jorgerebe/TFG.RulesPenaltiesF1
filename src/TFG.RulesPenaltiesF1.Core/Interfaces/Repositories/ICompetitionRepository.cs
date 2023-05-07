using TFG.RulesPenaltiesF1.Core.Entities.CompetitionAggregate;

namespace TFG.RulesPenaltiesF1.Core.Interfaces.Repositories;

public interface ICompetitionRepository : IRepository<Competition>
{
	Task<Competition?> GetCompetitionById(int id);
	Task<Competition?> GetNextCompetitionThatCanBeStarted();
	Task<Competition?> GetCompetitionByIdWithParticipationsAsync(int id);
	Task<Competition?> GetCompetitionByIdWithSessionsAsync(int id);
}
