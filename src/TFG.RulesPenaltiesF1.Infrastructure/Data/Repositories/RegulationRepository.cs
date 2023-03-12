using Microsoft.EntityFrameworkCore;
using TFG.RulesPenaltiesF1.Core.Entities.RegulationAggregate;
using TFG.RulesPenaltiesF1.Core.Interfaces;

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
      return await _dbContext.Set<Regulation>().AnyAsync(r => r.Name == name);
   }
}
