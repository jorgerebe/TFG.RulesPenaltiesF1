using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TFG.RulesPenaltiesF1.Web.ViewModels;

public class ParticipationInputViewModel
{
	[Required]
	public int CompetitionId { get; set; }

	public CompetitionViewModel Competition { get; set; } = new ();

	[Required]
	[DisplayName("Drivers")]
	[Range(2,2,ErrorMessage = "Each competitor must declare the participation of two drivers")]
	public List<int> DriverIds { get; set; } = new();

	[Required]
	public int CompetitorId { get; set; }

	public CompetitorViewModel Competitor { get; set; } = new();
}
