using TFG.RulesPenaltiesF1.Core.Entities;
using TFG.RulesPenaltiesF1.Core.Interfaces.Repositories;
using TFG.RulesPenaltiesF1.Web.Interfaces;
using TFG.RulesPenaltiesF1.Web.ViewModels;

namespace TFG.RulesPenaltiesF1.Web.Services;

public class DriverViewModelSevice : IDriverViewModelService
{
	private readonly IDriverRepository _repository;

	public DriverViewModelSevice(IDriverRepository repository)
	{
		_repository = repository;
	}

	public async Task<List<DriverViewModel>> GetAllDrivers()
	{
		List<DriverViewModel> driversViewModels = new();

		List<Driver> drivers = await _repository.GetAllDrivers();

		foreach(var driver in drivers)
		{
			driversViewModels.Add(MapEntityToViewModel(driver)!);
		}

		return driversViewModels;
	}

	public Task<DriverViewModel> GetDriverById(int id)
	{
		throw new NotImplementedException();
	}

	public DriverViewModel? MapEntityToViewModel(Driver driver)
	{
		if (driver is null)
		{
			return null;
		}

		DriverViewModel driverViewModel = new()
		{
			Id = driver.Id,
			DateBirth = driver.DateBirth,
			Competitor = driver.Competitor is not null ? new CompetitorViewModel() { Id = driver.Competitor!.Id, Name = driver.Competitor.Name} : null
		};

		return driverViewModel;
	}

	public Driver? MapViewModelToEntity(DriverViewModel driver)
	{
		if(driver is null)
		{
			return null;
		}

		if(driver.CompetitorId == -1)
		{
			return new Driver(driver.Name, driver.DateBirth, null);
		}
		else
		{
			return new Driver(driver.Name, driver.DateBirth, driver.CompetitorId);
		}
	}
}
