using Microsoft.EntityFrameworkCore;
using TFG.RulesPenaltiesF1.Core.Entities.RegulationAggregate;
using TFG.RulesPenaltiesF1.Core.Interfaces.Repositories;

namespace TFG.RulesPenaltiesF1.Infrastructure.Data.Repositories;
public class RegulationRepository : EfRepository<Regulation>, IRegulationRepository
{
   private readonly RulesPenaltiesF1DbContext _dbContext;

   public RegulationRepository(RulesPenaltiesF1DbContext dbContext) : base(dbContext)
   {
      _dbContext = dbContext;
   }

   public async Task<bool> ExistsRegulationByName(string name)
   {
      return await _dbContext.Set<Regulation>().AnyAsync(r => r.Name.ToLower() == name.ToLower());
   }

	public async Task<Regulation?> GetRegulationByIdAsync(int id)
   {
      return await _dbContext.Set<Regulation>()
         .Include(r => r.Articles)
            .ThenInclude(a => a.Article)
               .ThenInclude(a => a!.SubArticles)
         .Include(r => r.Penalties)
            .ThenInclude(p => p.Penalty)
               .ThenInclude(p => p!.PenaltyType)
         .FirstAsync(r => r.Id == id);
   }

	public async Task<Regulation?> GetRegulationByCompetitionId(int competitionId)
	{
		return await _dbContext.Set<Regulation>()
			.Where(r => r.Id == _dbContext.Season.Where(s => s.Competitions.Any(c => c.Id == competitionId)).First().RegulationId)
			.Include(r => r.Articles)
				.ThenInclude(a => a.Article)
			.Include(r => r.Penalties)
				.ThenInclude(p => p.Penalty)
					.ThenInclude(p => p!.PenaltyType)
			.FirstOrDefaultAsync();
	}
}
