using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TFG.RulesPenaltiesF1.Core.Entities.CompetitionAggregate;
using TFG.RulesPenaltiesF1.Core.Entities;

namespace TFG.RulesPenaltiesF1.Web.ViewModels;

public class SeasonViewModel
{
   public int Id { get; set; }

   [Required]
	[Range(1950, 2100, ErrorMessage ="A season must be on or before 2100 and on or after 1950")]
   public int Year { get; set; }

   [Required]
	[MinLength(2, ErrorMessage ="There must be at least two competitors")]
   public List<int> Competitors { get; set; } = new();

   public List<CompetitorViewModel> CompetitorsContent { get; set; } = new();


   [Required]
   [MinLength(2)]
   public List<CompetitionViewModel> Competitions { get; set; } = new();

   [Required]
	[DisplayName("Regulation")]
   public int RegulationId { get; set; } = new();


   public RegulationViewModel? Regulation { get; set; }


	public static Season? MapViewModelToEntity(SeasonViewModel season)
	{
		if (season is null)
		{
			return null;
		}

		List<Competitor> competitors = new();

		foreach (var competitor in season.Competitors)
		{
			competitors.Add(new Competitor(competitor));
		}

		List<Competition> competitions = new();

		foreach (var competition in season.Competitions)
		{
			competitions.Add(new Competition(competition.CircuitId, competition.Name, competition.IsSprint, competition.Week));
		}

		Season seasonEntity = new(season.Year, competitors, competitions, season.RegulationId);

		return seasonEntity;
	}

	public static SeasonViewModel? MapEntityToViewModel(Season season)
	{
		if (season is null)
		{
			return null;
		}

		SeasonViewModel seasonViewModel = new()
		{
			Id = season.Id,
			Year = season.Year,
			Regulation = new RegulationViewModel() { Id = season.RegulationId, Name = season.Regulation == null ? "" : season.Regulation.Name },
			RegulationId = season.RegulationId
		};

		if (season.Competitors != null)
		{
			foreach (var competitor in season.Competitors)
			{
				seasonViewModel.CompetitorsContent.Add(CompetitorViewModel.MapEntityToViewModel(competitor)!);
			}
		}

		if (season.Competitions != null)
		{
			foreach (var competition in season.Competitions)
			{
				seasonViewModel.Competitions.Add(CompetitionViewModel.MapEntityToViewModel(competition)!);
			}
		}

		return seasonViewModel;
	}


}
