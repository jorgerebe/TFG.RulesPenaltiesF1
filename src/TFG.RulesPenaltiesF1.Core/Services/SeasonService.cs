﻿using TFG.RulesPenaltiesF1.Core.Entities;
using TFG.RulesPenaltiesF1.Core.Entities.CompetitionAggregate;
using TFG.RulesPenaltiesF1.Core.Interfaces.Repositories;
using TFG.RulesPenaltiesF1.Core.Interfaces.Services;

namespace TFG.RulesPenaltiesF1.Core.Services;

public class SeasonService : ISeasonService
{
	private readonly ISeasonRepository _repository;

	public SeasonService(ISeasonRepository repository)
	{
		_repository = repository;
	}

	public async Task CreateSeasonAsync(Season season)
	{
		ArgumentNullException.ThrowIfNull(season);

		await _repository.AddSeason(season);
	}
}
