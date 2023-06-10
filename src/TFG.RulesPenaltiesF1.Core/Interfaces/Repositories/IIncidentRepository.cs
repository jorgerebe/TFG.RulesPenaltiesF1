using TFG.RulesPenaltiesF1.Core.Entities.IncidentAggregate;

namespace TFG.RulesPenaltiesF1.Core.Interfaces.Repositories;

public interface IIncidentRepository : IRepository<Incident>
{
	public Task<List<Incident>> GetIncidents();
	public Task<List<Incident>> GetIncidentsWithPointsFromLastYearToCurrentWeek(int seasonId, int week);
}
