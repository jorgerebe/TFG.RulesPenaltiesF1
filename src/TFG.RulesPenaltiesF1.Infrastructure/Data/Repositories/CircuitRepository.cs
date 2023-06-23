using Microsoft.EntityFrameworkCore;
using TFG.RulesPenaltiesF1.Core.Entities;
using TFG.RulesPenaltiesF1.Core.Interfaces.Repositories;

namespace TFG.RulesPenaltiesF1.Infrastructure.Data.Repositories;
public class CircuitRepository : EfRepository<Circuit>, ICircuitRepository
{
   private readonly RulesPenaltiesF1DbContext _dbContext;

   public CircuitRepository(RulesPenaltiesF1DbContext dbContext) : base(dbContext)
   {
      _dbContext = dbContext;
   }

   public async Task<List<Circuit>> GetAllCircuits()
   {
      return await _dbContext.Circuit
                     .Include(c => c.Country)
							.AsNoTracking()
                     .ToListAsync();
   }

   public async Task<Circuit?> GetCircuitById(int id)
   {
      return await _dbContext.Circuit
                    .Where(b => b.Id == id)
                    .Include(b => b.Country)
                    .FirstOrDefaultAsync();
   }

	public async Task<Circuit?> GetCircuitByName(string name)
	{
		return await _dbContext.Circuit
			.Where(c => c.Name.ToLower() == name.ToLower())
			.FirstOrDefaultAsync();
	}
}
