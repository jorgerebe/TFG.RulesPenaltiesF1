using Microsoft.EntityFrameworkCore;
using TFG.RulesPenaltiesF1.Core.Entities;
using TFG.RulesPenaltiesF1.Core.Entities.CompetitionAggregate;
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
			.Include(d => d.Competitor).AsNoTracking().FirstOrDefaultAsync();
	}

	public async Task<Driver?> GetDriverByName(string name)
	{
		var pepe = name.ToLower().Replace("\t", " ").Replace(" ", "");
		return await _dbContext.Set<Driver>()
			.Where(d => d.Name.ToLower().Replace("\t", " ").Replace(" ", "") == name.ToLower().Replace("\t", " ").Replace(" ", "")).FirstOrDefaultAsync();
	}

	public async Task<Driver?> GetDriverByParticipationId(int participationId)
	{
		var participation = await _dbContext.Set<Participation>()
											.Where(p => p.Id == participationId).FirstOrDefaultAsync();

		if(participation is null)
		{
			return null;
		}

		return participation.Driver;
	}

	public async Task<List<Driver>> GetDriversInCompetitor(int competitorId)
	{
		return await _dbContext.Set<Driver>()
			.Where(d => d.CompetitorId == competitorId)
			.AsNoTracking()
			.ToListAsync();
	}

	public async Task<List<Driver>> GetDriversWithPenaltyPointsLessThanTwelve()
	{
		return await _dbContext.Set<Driver>()
			.Where(d => d.LicensePoints > 0 && d.LicensePoints < 12).ToListAsync();
	}

	public async Task<List<Driver>> GetDriversWithTwelvePointsAndNoPenaltyLastCompetition(int competitionId)
	{
		return await _dbContext.Set<Driver>()
			.Where(d => d.LicensePoints == 12 && _dbContext.Competition.Where(c => c.Id == competitionId - 1 && c.Sessions.Any(s => s.Incidents.Any(p => p.Participation!.DriverId == d.Id))).ToList().Count == 0).ToListAsync();
	}

	public async Task UpdateTeam(Driver driver)
	{
		_dbContext.Driver.Attach(driver);
		_dbContext.Entry(driver).Property(d => d.CompetitorId).IsModified = true;
		await _dbContext.SaveChangesAsync();
	}
}
