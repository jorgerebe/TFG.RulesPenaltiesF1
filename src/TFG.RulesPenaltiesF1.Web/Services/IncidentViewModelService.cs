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

	public async Task<List<IncidentViewModel>> GetIncidents()
	{
		List<Incident> incidents =  await _repository.GetIncidents();

		List<IncidentViewModel> incidentViewModels = new List<IncidentViewModel>();

		foreach(var incident in incidents)
		{
			incidentViewModels.Add(IncidentViewModel.MapEntityToViewModel(incident));
		}

		return incidentViewModels;
	}
}
