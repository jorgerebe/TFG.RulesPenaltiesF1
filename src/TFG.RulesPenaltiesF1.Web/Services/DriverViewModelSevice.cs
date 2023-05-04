﻿using TFG.RulesPenaltiesF1.Core.Entities;
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
			driversViewModels.Add(DriverViewModel.MapEntityToViewModel(driver)!);
		}

		return driversViewModels;
	}

	public async Task<DriverViewModel?> GetDriverById(int id)
	{
		var driver = await _repository.GetDriverById(id);

		if(driver is null)
		{
			return null;
		}

		return DriverViewModel.MapEntityToViewModel(driver!);
	}

	public async Task<bool> ExistsDriverByName(string name)
	{
		return await _repository.GetDriverByName(name) is not null;
	}
}
