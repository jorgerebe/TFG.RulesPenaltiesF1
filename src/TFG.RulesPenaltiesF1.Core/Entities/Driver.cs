namespace TFG.RulesPenaltiesF1.Core.Entities;

public class Driver
{
	public string Name { get; set; }
	public DateOnly DateBirth { get; set; }
	public int LicensePoints { get; set; }

	public Competitor? Competitor { get; set; }
	public int? CompetitorId { get; set; }

	public Driver(string name, DateOnly dateBirth)
	{
		ArgumentException.ThrowIfNullOrEmpty(name);
		ArgumentNullException.ThrowIfNull(dateBirth);

		Name = name;
		DateBirth = dateBirth;
		LicensePoints = 0;
		CompetitorId = null;
	}

	public Driver(string name, DateOnly dateBirth, Competitor competitor)
	{
		ArgumentException.ThrowIfNullOrEmpty(name);
		ArgumentNullException.ThrowIfNull(dateBirth);

		Name = name;
		DateBirth = dateBirth;
		LicensePoints = 0;
		AddTeam(competitor);
	}

	public Driver(string name, DateOnly dateBirth, int competitorId)
	{
		ArgumentException.ThrowIfNullOrEmpty(name);
		ArgumentNullException.ThrowIfNull(dateBirth);

		Name = name;
		DateBirth = dateBirth;
		LicensePoints = 0;
		CompetitorId = competitorId;
	}

	public void AddTeam(Competitor competitor)
	{
		ArgumentNullException.ThrowIfNull(competitor);

		Competitor = competitor;
	}
}
