using Microsoft.EntityFrameworkCore;
using TFG.RulesPenaltiesF1.Core.Entities.IncidentAggregate;
using TFG.RulesPenaltiesF1.Core.Interfaces.Repositories;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace TFG.RulesPenaltiesF1.Infrastructure.Data.Repositories;

public class IncidentRepository : EfRepository<Incident>, IIncidentRepository
{
	private readonly RulesPenaltiesF1DbContext _dbContext;

	public IncidentRepository(RulesPenaltiesF1DbContext dbContext) : base(dbContext)
	{
		this._dbContext = dbContext;
	}

	public async Task<List<Incident>> GetIncidents(int? driver, int? session)
	{
		var incidentsQuery = _dbContext.Set<Incident>()
			.Include(i => i.Session)
				.ThenInclude(s => s!.Competition)
					.ThenInclude(c => c!.Season)
			.Include(i => i.Session)
				.ThenInclude(s => s!.Competition)
					.ThenInclude(c => c!.Circuit)
			.Include(i => i.Session)
			.AsQueryable();

		if (driver.HasValue && session.HasValue)
		{
			incidentsQuery = incidentsQuery.Where(i => i.Participation!.Driver!.Id == driver.Value && i.Session!.SessionType == session.Value);
		}
		else if (driver.HasValue)
		{
			incidentsQuery = incidentsQuery.Where(i => i.Participation!.Driver!.Id == driver.Value);
		}
		else if (session.HasValue)
		{
			incidentsQuery = incidentsQuery.Where(i => i.Session!.SessionType == session.Value);
		}

		return await incidentsQuery.AsNoTracking().ToListAsync();
	}

	public async Task<List<Incident>> GetIncidentsWithPointsFromLastYearToCurrentWeek(int seasonId, int week)
	{
		var competitionsFromLastYearToCurrentWeek = await _dbContext.Competition.Where(c => c.SeasonId == seasonId || (c.SeasonId == seasonId - 1 && c.Week < week)).Include(c => c.Sessions).ThenInclude(s => s.Incidents).ToListAsync();

		return await _dbContext.Set<Incident>()
			.Where(i => i.LicensePoints != null && _dbContext.Session.Where(s => (s.Competition!.SeasonId == seasonId || (s.Competition.SeasonId == seasonId - 1 && week < s.Competition.Week)) && s.Incidents.Any(nestedIncident => nestedIncident.Id == i.Id)).ToList().Count > 0).ToListAsync();
	}
}
