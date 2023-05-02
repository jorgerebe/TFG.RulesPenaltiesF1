using Microsoft.EntityFrameworkCore;
using TFG.RulesPenaltiesF1.Core.Entities;
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
			.Include(c => c.Sessions)
			.AsNoTracking()
			.FirstOrDefaultAsync();
	}

	public async Task<Competition?> GetNextCompetitionThatCanBeStarted()
	{
		return await _dbContext.Set<Competition>()
			.Where(c => c.CompetitionState == 1 && c.Week <= _dbContext.Competition.
																			 Where(y => y.SeasonId == c.SeasonId).Min(y => y.Week)
															&& _dbContext.Competition
																	.Where(y => y.SeasonId == c.SeasonId)
																	.All(y => y.CompetitionState != 2))
			.Include(c => c.Circuit)
			.Include(c => c.Season)
			.AsNoTracking()
			.FirstOrDefaultAsync();
	}
}
