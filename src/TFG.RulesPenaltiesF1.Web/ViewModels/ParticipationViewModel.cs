namespace TFG.RulesPenaltiesF1.Web.ViewModels;

public class ParticipationViewModel
{
	public int Id { get; set; }

	public int CompetitionId { get; set; }
	public CompetitionViewModel? Competition { get; set; }

	public int DriverId { get; set; }

	public DriverViewModel? Driver { get; set; }

	public int CompetitorId { get; set; }
	public CompetitorViewModel? Competitor { get; set; }
}
