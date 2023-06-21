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
			.Where(p => p.Shown == true)
         .ToListAsync();
   }

	public async Task<Penalty?> GetLimitLicensePointsPenalty()
	{
		var pepe = await _dbContext.Disqualification.ToListAsync();

		return await _dbContext.Disqualification
			.Where(d => d.Type.Equals(DisqualificationTypeEnum.LicensePointsLimit.Value)).FirstOrDefaultAsync();
	}

	public async Task<PenaltyType?> GetPenaltyTypeByName(string name)
	{
		return await _dbContext.PenaltyType
			.Where(pt => pt.Name == name).FirstOrDefaultAsync();
	}

	public async Task<PenaltyType> AddPenaltyType(PenaltyType penaltyType)
	{
		_dbContext.Add(penaltyType);
		await _dbContext.SaveChangesAsync();
		return penaltyType;
	}
}
