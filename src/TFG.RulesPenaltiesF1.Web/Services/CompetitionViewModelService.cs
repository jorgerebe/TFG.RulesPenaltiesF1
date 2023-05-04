﻿using TFG.RulesPenaltiesF1.Core.Entities.CompetitionAggregate;
using TFG.RulesPenaltiesF1.Core.Interfaces.Repositories;
using TFG.RulesPenaltiesF1.Web.Interfaces;
using TFG.RulesPenaltiesF1.Web.ViewModels;

namespace TFG.RulesPenaltiesF1.Web.Services;

public class CompetitionViewModelService : ICompetitionViewModelService
{
	private readonly ICompetitionRepository _repository;
	private readonly ICompetitorViewModelService _competitorViewModelService;
	private readonly ISeasonViewModelService _seasonViewModelService;

	public CompetitionViewModelService(ICompetitionRepository repository, ICompetitorViewModelService competitorViewModelService,
		ISeasonViewModelService seasonViewModelService)
	{
		_repository = repository;
		_competitorViewModelService = competitorViewModelService;
		_seasonViewModelService = seasonViewModelService;
	}

	public async Task<CompetitionViewModel?> GetByIdAsync(int id)
	{
		Competition? competition = await _repository.GetCompetitionById(id);

		if(competition is null)
		{
			return null;
		}

		return MapEntityToViewModel(competition);
	}

	public async Task<bool> CanStartCompetition(int id)
	{
		Competition? competition = await _repository.GetNextCompetitionThatCanBeStarted();

		if(competition == null)
		{
			return false;
		}

		if (competition.Id == id)
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	public async Task<bool> CanAddParticipation(int idCompetition, string idTeamPrincipal)
	{
		var competition = await GetByIdAsync(idCompetition);

		if(competition is null)
		{
			return false;
		}

		bool anySessionStarted = false;

		foreach (var session in competition.Sessions)
		{
			if (!session.State.Equals(SessionStateEnum.NotStarted))
			{
				anySessionStarted = true;
			}
		}

		if (anySessionStarted)
		{
			return false;
		}

		var competitor = _competitorViewModelService.GetCompetitorByTeamPrincipal(idTeamPrincipal);

		if(competitor is null)
		{
			return false;
		}

		return await _seasonViewModelService.CompetitorPresentInSeasonOfCompetition(idCompetition, competitor.Id);
	}

	public CompetitionViewModel MapEntityToViewModel(Competition competition)
	{
		ArgumentNullException.ThrowIfNull(competition);

		CompetitionViewModel competitionViewModel = new()
		{
			SeasonId = competition.Season!.Id,
			Year = competition.Season!.Year,
			Id = competition.Id,
			Name = competition.Name,
			CircuitId = competition.CircuitId,
			Circuit = new() { Name = competition.Circuit!.Name },
			IsSprint = competition.IsSprint,
			Week = competition.Week,
			CompetitionState = competition.CompetitionState
		};

		foreach(var session in competition.Sessions)
		{
			competitionViewModel.Sessions.Add(
				new SessionViewModel()
					{
						SessionId = session.Id,
						State = session.State,
						Type = session.SessionType
					}
				);
		}

		return competitionViewModel;
	}

	public Competition? MapViewModelToEntity(CompetitionViewModel competition)
	{
		throw new NotImplementedException();
	}
}
