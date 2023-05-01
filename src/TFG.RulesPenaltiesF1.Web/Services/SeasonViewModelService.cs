using TFG.RulesPenaltiesF1.Core.Entities;
using TFG.RulesPenaltiesF1.Core.Entities.CompetitionAggregate;
using TFG.RulesPenaltiesF1.Core.Interfaces.Repositories;
using TFG.RulesPenaltiesF1.Web.Interfaces;
using TFG.RulesPenaltiesF1.Web.ViewModels;

namespace TFG.RulesPenaltiesF1.Web.Services;

public class SeasonViewModelService : ISeasonViewModelService
{
	private readonly ISeasonRepository _repository;
	private readonly ICompetitorViewModelService _competitorViewModelService;
	private readonly ICompetitionViewModelService _competitionViewModelService;


	public SeasonViewModelService(ISeasonRepository repository, ICompetitorViewModelService competitorViewModelService,
		ICompetitionViewModelService competitionViewModelService)
   {
		_repository = repository;
		_competitorViewModelService = competitorViewModelService;
		_competitionViewModelService = competitionViewModelService;
	}


	public async Task<List<SeasonViewModel>> GetSeasonsAsync()
	{
		var seasons = await _repository.GetAllAsync();

		List<SeasonViewModel> seasonsViewModel = new();

		foreach(var season in seasons)
		{
			seasonsViewModel.Add(MapEntityToViewModel(season)!);
		}

		return seasonsViewModel;
	}


	public async Task<SeasonViewModel?> GetByIdAsync(int id)
   {
		Season? season = await _repository.GetSeasonById(id);

		if(season is null)
		{
			return null;
		}

		SeasonViewModel seasonViewModel = MapEntityToViewModel(season)!;

		return seasonViewModel;
   }

	public async Task<bool> ExistsSeasonInYear(int year)
	{
		var season = await _repository.GetSeasonByYear(year);

		return season != null;
	}

	public Season? MapViewModelToEntity(SeasonViewModel season)
	{
		if(season is null)
		{
			return null;
		}

		List<Competitor> competitors = new();

		foreach(var competitor in season.Competitors)
		{
			competitors.Add(new Competitor(competitor));
		}

		List<Competition> competitions = new();

		foreach(var competition in season.Competitions)
		{
			competitions.Add(new Competition(competition.CircuitId, competition.Name, competition.IsSprint, competition.Week));
		}

		Season seasonEntity = new(season.Year, competitors, competitions, season.RegulationId);

		return seasonEntity;
	}

	public SeasonViewModel? MapEntityToViewModel(Season season)
	{
		if(season is null)
		{
			return null;
		}

		SeasonViewModel seasonViewModel = new()
		{
			Id = season.Id,
			Year = season.Year,
			Regulation = new RegulationViewModel() { Id = season.RegulationId, Name = season.Regulation == null ? "" : season.Regulation.Name  },
			RegulationId = season.RegulationId
		};

		if(season.Competitors != null)
		{
			foreach(var competitor in season.Competitors)
			{
				seasonViewModel.CompetitorsContent.Add(_competitorViewModelService.MapEntityToViewModel(competitor)!);
			}
		}

		if(season.Competitions != null)
		{
			foreach(var competition in season.Competitions)
			{
				seasonViewModel.Competitions.Add(_competitionViewModelService.MapEntityToViewModel(competition)!);
			}
		}

		return seasonViewModel;
	}

	public async Task<bool> CanCreateAnotherSeason()
	{
		return await _repository.GetCurrentSeason() is null;
	}
}
