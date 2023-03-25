using Microsoft.EntityFrameworkCore;
using TFG.RulesPenaltiesF1.Core.Entities.Penalties;
using TFG.RulesPenaltiesF1.Core.Interfaces.Repositories;

namespace TFG.RulesPenaltiesF1.Infrastructure.Data.Repositories;
public class PenaltyRepository : EfRepository<Penalty>, IPenaltyRepository
{
   private readonly RulesPenaltiesF1DbContext _dbContext;

   public PenaltyRepository(RulesPenaltiesF1DbContext dbContext) : base(dbContext)
   {
      _dbContext = dbContext;
   }

   public async Task<List<Penalty>> GetAllPenalties()
   {
      return await _dbContext.Penalty
         .Include(p => p.PenaltyType)
         .ToListAsync();
   }
}
