﻿using TFG.RulesPenaltiesF1.Core.Entities.IncidentAggregate;
using TFG.RulesPenaltiesF1.Core.Interfaces.Repositories;
using TFG.RulesPenaltiesF1.Web.Interfaces;
using TFG.RulesPenaltiesF1.Web.ViewModels;

namespace TFG.RulesPenaltiesF1.Web.Services;

public class IncidentViewModelService : IIncidentViewModelService
{
	private readonly IIncidentRepository _repository;

	public IncidentViewModelService(IIncidentRepository repository)
	{
		_repository = repository;
	}

	public async Task<PaginatedList<IncidentViewModel>> GetIncidents(string sortOrder, int? driver, int? session, int pageIndex, int pageSize)
	{
		List<Incident> incidents =  await _repository.GetIncidents(sortOrder, driver, session);

		List<IncidentViewModel> incidentViewModels = new List<IncidentViewModel>();

		foreach(var incident in incidents)
		{
			incidentViewModels.Add(IncidentViewModel.MapEntityToViewModel(incident));
		}

		PaginatedList<IncidentViewModel> paginatedIncidents = PaginatedList<IncidentViewModel>.Create(incidentViewModels, pageIndex, pageSize);

		return paginatedIncidents;
	}


	public async Task<IncidentViewModel?> GetIncidentById(int? id)
	{
		if(!id.HasValue)
		{
			return null!;
		}

		Incident? incident = await _repository.GetIncidentById((int)id);

		if(incident is null)
		{
			return null!;
		}

		return IncidentViewModel.MapEntityToViewModel(incident);
	}
}
