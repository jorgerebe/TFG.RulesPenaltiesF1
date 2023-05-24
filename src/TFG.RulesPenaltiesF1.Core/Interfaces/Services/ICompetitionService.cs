using TFG.RulesPenaltiesF1.Core.Entities;
using TFG.RulesPenaltiesF1.Core.Entities.CompetitionAggregate;

namespace TFG.RulesPenaltiesF1.Core.Interfaces.Services;

public interface ICompetitionService
{
	Task<Competition> StartCompetition(int id);
	Task AddParticipations(List<Participation> participations);
	Task AdvanceSession(int id);
	Task AddIncident(Incident incident);
}
