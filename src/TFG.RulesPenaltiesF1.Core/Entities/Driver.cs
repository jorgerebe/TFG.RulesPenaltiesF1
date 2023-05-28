using TFG.RulesPenaltiesF1.Core.Interfaces;

namespace TFG.RulesPenaltiesF1.Core.Entities;

public class Driver : EntityBase, IAggregateRoot
{
	const int MAX_LICENSE_POINTS = 12;

	public string Name { get; set; } = string.Empty;
	public DateOnly DateBirth { get; set; }
	public int LicensePoints { get; set; }

	public Competitor? Competitor { get; set; }
	public int? CompetitorId { get; set; }

	private Driver() { }

	public Driver(string name, DateOnly dateBirth, Competitor? competitor)
	{
		ArgumentException.ThrowIfNullOrEmpty(name);
		ArgumentNullException.ThrowIfNull(dateBirth);

		Name = name;
		DateBirth = dateBirth;
		LicensePoints = 0;
		AddTeam(competitor);
		CompetitorId = competitor?.Id;
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

	public void AddTeam(Competitor? competitor)
	{
		Competitor = competitor;
	}

	public void AddLicensePoints(int points)
	{
		if((points + LicensePoints) > MAX_LICENSE_POINTS)
		{
			throw new ArgumentException($"The driver can not have more than {MAX_LICENSE_POINTS} license points");
		}

		LicensePoints += points;
	}
}
