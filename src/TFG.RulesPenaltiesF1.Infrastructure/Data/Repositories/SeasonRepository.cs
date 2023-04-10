﻿using Microsoft.EntityFrameworkCore;
using TFG.RulesPenaltiesF1.Core.Entities;
using TFG.RulesPenaltiesF1.Core.Interfaces.Repositories;

namespace TFG.RulesPenaltiesF1.Infrastructure.Data.Repositories;

public class SeasonRepository : EfRepository<Season>, ISeasonRepository
{
	private readonly RulesPenaltiesF1DbContext _dbContext;

	public SeasonRepository(RulesPenaltiesF1DbContext dbContext) : base(dbContext)
	{
		_dbContext = dbContext;
	}

	public async Task<Season?> GetSeasonByYear(int year)
	{
		var season = await _dbContext.Set<Season>()
			.Where(s => s.Year == year)
			.FirstOrDefaultAsync();

		return season;
	}

	public async Task<Season?> GetSeasonById(int id)
	{
		var season = await _dbContext.Set<Season>()
			.Where(s => s.Id == id)
			.Include(s => s.Regulation)
			.Include(s => s.Competitions)
				.ThenInclude(c => c.Circuit)
			.Include(s => s.Competitors)
			.FirstOrDefaultAsync();

		return season;
	}

	public async Task<Season> AddSeason(Season season)
	{
		_dbContext.Add(season);

		foreach(var competitor in season.Competitors)
		{
			_dbContext.Competitor.Attach(competitor);
		}

		await _dbContext.SaveChangesAsync();
		return season;
	}
}
