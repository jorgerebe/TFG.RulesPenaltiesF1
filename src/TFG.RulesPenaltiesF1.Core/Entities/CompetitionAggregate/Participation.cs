namespace TFG.RulesPenaltiesF1.Core.Entities.CompetitionAggregate;

public class Participation
{
	public int CompetitionId { get; set; }
	public Competition? Competition { get; set; }

	public int CompetitorId { get; set; }
	public Competitor? Competitor { get; set; }

	public int DriverId { get; set; }
	public Driver? Driver { get; set; }

	public Participation(int competitionId, int competitorId, int driverId)
	{
		CompetitionId = competitionId;
		CompetitorId = competitorId;
		DriverId = driverId;
	}

	public Participation(Competition competition, Competitor competitor, Driver driver)
	{
		ArgumentNullException.ThrowIfNull(competition);
		ArgumentNullException.ThrowIfNull(competitor);
		ArgumentNullException.ThrowIfNull(driver);

		Competition = competition;
		CompetitionId = competition.Id;

		Competitor = competitor;
		CompetitorId = competitor.Id;

		Driver = driver;
		DriverId = driver.Id;
	}
}
