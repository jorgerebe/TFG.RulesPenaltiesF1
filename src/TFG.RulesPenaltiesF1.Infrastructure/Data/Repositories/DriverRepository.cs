using Microsoft.EntityFrameworkCore;
using TFG.RulesPenaltiesF1.Core.Entities;
using TFG.RulesPenaltiesF1.Core.Interfaces.Repositories;

namespace TFG.RulesPenaltiesF1.Infrastructure.Data.Repositories;

public class DriverRepository : EfRepository<Driver>, IDriverRepository
{
	private readonly RulesPenaltiesF1DbContext _dbContext;

	public DriverRepository(RulesPenaltiesF1DbContext dbContext) : base(dbContext)
	{
		_dbContext = dbContext;
	}

	public async Task<List<Driver>> GetAllDrivers()
	{
		return await _dbContext.Set<Driver>()
			.Include(d => d.Competitor).ToListAsync();
	}

	public async Task<Driver?> GetDriverById(int id)
	{
		return await _dbContext.Set<Driver>()
			.Where(d => d.Id == id)
			.Include(d => d.Competitor).FirstOrDefaultAsync();
	}
}
