using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TFG.RulesPenaltiesF1.Core.Entities.CompetitionAggregate;

namespace TFG.RulesPenaltiesF1.Web.ViewModels;

public class ParticipationInputViewModel
{
	[Required]
	public int CompetitionId { get; set; }

	public CompetitionViewModel? Competition { get; set; }

	[Required]
	[DisplayName("Drivers")]
	[MinLength(2, ErrorMessage = "Each competitor must declare the participation of two drivers")]
	[MaxLength(2, ErrorMessage = "Each competitor must declare the participation of two drivers")]
	public List<int> DriverIds { get; set; } = new();

	[Required]
	public int CompetitorId { get; set; }

	public CompetitorViewModel? Competitor { get; set; }

	public static List<Participation> MapViewModelToEntity(ParticipationInputViewModel viewModel)
	{
		List<Participation> participations = new();

		foreach(var driverId in viewModel.DriverIds)
		{
			participations.Add(new (viewModel.CompetitionId, viewModel.CompetitorId, driverId));
		}

		return participations;
	}
}
