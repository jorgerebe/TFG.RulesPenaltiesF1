using TFG.RulesPenaltiesF1.Core.Entities;
using TFG.RulesPenaltiesF1.Core.Interfaces.Repositories;
using TFG.RulesPenaltiesF1.Core.Interfaces.Services;

namespace TFG.RulesPenaltiesF1.Core.Services;

public class SeasonService : ISeasonService
{
	private readonly IRepository<Season> _repository;

	public SeasonService(IRepository<Season> repository)
	{
		_repository = repository;
	}

	public async Task CreateSeasonAsync(Season season)
	{
		ArgumentNullException.ThrowIfNull(season);

		await _repository.Add(season);
	}
}
