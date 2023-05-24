using Microsoft.EntityFrameworkCore;
using TFG.RulesPenaltiesF1.Core.Entities.CompetitionAggregate;
using TFG.RulesPenaltiesF1.Core.Interfaces.Repositories;

namespace TFG.RulesPenaltiesF1.Infrastructure.Data.Repositories;

public class CompetitionRepository : EfRepository<Competition>, ICompetitionRepository
{
	private readonly RulesPenaltiesF1DbContext _dbContext;

	public CompetitionRepository(RulesPenaltiesF1DbContext dbContext) : base(dbContext)
	{
		_dbContext = dbContext;
	}

	public async Task<Competition?> GetCompetitionById(int id)
	{
		return await _dbContext.Set<Competition>()
			.Where(c => c.Id == id)
			.Include(c => c.Circuit)
			.Include(c => c.Season)
				.ThenInclude(s => s!.Competitors)
			.Include(c => c.Sessions)
				.ThenInclude(s => s.Incidents)
			.Include(c => c.Participations.OrderBy(p => p.Competitor!.Name))
				.ThenInclude(p => p.Competitor)
			.Include(c => c.Participations.OrderBy(p => p.Competitor!.Name))
				.ThenInclude(p => p.Driver)
			.AsNoTracking()
			.FirstOrDefaultAsync();
	}

	public async Task<Competition?> GetNextCompetitionThatCanBeStarted()
	{
		return await _dbContext.Set<Competition>()
			.Where(c => c.State == 1 && c.Week <= _dbContext.Competition.
																			 Where(y => y.State != CompetitionStateEnum.Finished.Value && y.SeasonId == c.SeasonId).Min(y => y.Week))
			.Include(c => c.Circuit)
			.Include(c => c.Season)
			.AsNoTracking()
			.FirstOrDefaultAsync();
	}

	public async Task<Competition?> GetCompetitionByIdWithParticipationsAsync(int id)
	{
		return await _dbContext.Set<Competition>()
			.Where(c => c.Id == id)
			.Include(c => c.Participations)
			.FirstOrDefaultAsync();
	}

	public async Task<Competition?> GetCompetitionByIdWithSessionsAsync(int id)
	{
		return await _dbContext.Set<Competition>()
			.Where(c => c.Id == id)
			.Include(c => c.Sessions)
			.FirstOrDefaultAsync();
	}

	public async Task<Competition?> GetCompetitionBySessionId(int sessionId)
	{
		return await _dbContext.Set<Competition>()
			.Where(c => c.Sessions.Any(s => s.Id == sessionId))
			.Include(c => c.Sessions).FirstOrDefaultAsync();
	}
}
