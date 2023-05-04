namespace TFG.RulesPenaltiesF1.Web.ViewModels;

public class ParticipationViewModel
{
	public int CompetitionId { get; set; }
	public CompetitionViewModel? Competition { get; set; }

	public int Driver1Id { get; set; }
	public int Driver2Id { get; set; }

	public DriverViewModel? Driver1 { get; set; }
	public DriverViewModel? Driver2 { get; set; }

	public int CompetitorId { get; set; }
	public CompetitorViewModel? Competitor { get; set; }
}
