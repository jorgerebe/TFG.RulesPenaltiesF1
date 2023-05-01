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
			.AsNoTracking()
			.FirstOrDefaultAsync();
	}
}
