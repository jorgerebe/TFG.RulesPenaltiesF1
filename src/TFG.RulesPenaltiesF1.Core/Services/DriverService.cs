using TFG.RulesPenaltiesF1.Core.Entities;
using TFG.RulesPenaltiesF1.Core.Interfaces.Repositories;
using TFG.RulesPenaltiesF1.Core.Interfaces.Services;

namespace TFG.RulesPenaltiesF1.Core.Services;

public class DriverService : IDriverService
{
	private readonly IRepository<Driver> _repository;

	public DriverService(IRepository<Driver> repository)
	{
		_repository = repository;
	}

	public async Task CreateDriverAsync(Driver driver)
	{
		ArgumentNullException.ThrowIfNull(driver);

		await _repository.Add(driver);
	}

	public async Task UpdateDriverAsync(Driver driver)
	{
		ArgumentNullException.ThrowIfNull(driver);

		await _repository.Update(driver);
	}
}
