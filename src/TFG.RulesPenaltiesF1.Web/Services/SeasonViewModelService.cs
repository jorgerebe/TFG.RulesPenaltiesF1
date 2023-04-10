using TFG.RulesPenaltiesF1.Core.Entities;
using TFG.RulesPenaltiesF1.Core.Entities.RegulationAggregate;
using TFG.RulesPenaltiesF1.Core.Interfaces.Repositories;
using TFG.RulesPenaltiesF1.Web.Interfaces;
using TFG.RulesPenaltiesF1.Web.ViewModels;

namespace TFG.RulesPenaltiesF1.Web.Services;

public class SeasonViewModelService : ISeasonViewModelService
{
	private readonly ISeasonRepository _repository;

   public SeasonViewModelService(ISeasonRepository repository)
   {
		_repository = repository;
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


	public Task<SeasonViewModel?> GetByIdAsync(int id)
   {
      throw new NotImplementedException();
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

		Season seasonEntity = new(season.Year, competitors, competitions, new Regulation(season.RegulationId));

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

		};

		return seasonViewModel;
	}
}
