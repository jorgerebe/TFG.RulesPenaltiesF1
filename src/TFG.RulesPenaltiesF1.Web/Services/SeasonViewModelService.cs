using TFG.RulesPenaltiesF1.Core.Entities;
using TFG.RulesPenaltiesF1.Core.Interfaces;
using TFG.RulesPenaltiesF1.Core.Interfaces.Repositories;
using TFG.RulesPenaltiesF1.Web.Interfaces;
using TFG.RulesPenaltiesF1.Web.ViewModels;

namespace TFG.RulesPenaltiesF1.Web.Services;

public class SeasonViewModelService : ISeasonViewModelService
{
	private readonly ISeasonRepository _repository;
	private readonly IDateTimeService _dateTimeService;

	public SeasonViewModelService(ISeasonRepository repository, IDateTimeService dateTimeService)
   {
		_repository = repository;
		_dateTimeService = dateTimeService;
	}


	public async Task<List<SeasonViewModel>> GetSeasonsAsync()
	{
		var seasons = await _repository.GetAllAsync();

		List<SeasonViewModel> seasonsViewModel = new();

		foreach(var season in seasons)
		{
			seasonsViewModel.Add(SeasonViewModel.MapEntityToViewModel(season)!);
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

		SeasonViewModel seasonViewModel = SeasonViewModel.MapEntityToViewModel(season)!;

		return seasonViewModel;
   }

	public async Task<bool> ExistsSeasonInYear(int year)
	{
		var season = await _repository.GetSeasonByYear(year);

		return season != null;
	}

	public async Task<bool> CompetitorPresentInSeasonOfCompetition(int competitionId, int competitorId)
	{
		var season = await _repository.GetSeasonByCompetitonAndCompetitor(competitionId, competitorId);

		return season is not null;
	}

	public async Task<bool> CanCreateAnotherSeason()
	{
		return await _repository.GetCurrentSeason() is null;
	}

	public async Task<int> GetYearLatestSeason()
	{
		Season? latestSeason = await _repository.GetLatestSeason();

		if(latestSeason is null)
		{
			return _dateTimeService.Now().Year;
		}
		else
		{
			return latestSeason.Year;
		}
	}
}
