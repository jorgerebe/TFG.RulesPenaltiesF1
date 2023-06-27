using TFG.RulesPenaltiesF1.Core.Interfaces;

namespace TFG.RulesPenaltiesF1.Core.Entities;

/// <summary>
/// Class <c>Driver</c> models a driver that can be part of a team
/// </summary>

public class Driver : EntityBase, IAggregateRoot
{
	public const int MAX_LICENSE_POINTS = 12;

	public string Name { get; set; } = string.Empty;
	public DateOnly DateBirth { get; set; }
	public int LicensePoints { get; set; }

	public Competitor? Competitor { get; set; }
	public int? CompetitorId { get; set; }

	private Driver() { }

	public Driver(string name, DateOnly dateBirth, Competitor? competitor, IDateTimeService dateTimeService)
	{
		CheckArguments(name, dateBirth, dateTimeService);

		Name = name;
		DateBirth = dateBirth;
		LicensePoints = 0;
		AddTeam(competitor);
	}

	public Driver(string name, DateOnly dateBirth, int competitorId, IDateTimeService dateTimeService)
	{
		CheckArguments(name, dateBirth, dateTimeService);

		Name = name;
		DateBirth = dateBirth;
		LicensePoints = 0;
		CompetitorId = competitorId;
	}

	/// <summary>
	/// Updates the team of the driver.
	/// <example>
	/// If the competitor is null, that means that the driver is no longer part of a team.
	/// </example>
	/// </summary>
	/// <param name="competitor">New competitor for the driver</param>

	public void AddTeam(Competitor? competitor)
	{
		Competitor = competitor;

		if(competitor is null)
		{
			CompetitorId = null;
		}
		else
		{
			CompetitorId = competitor.Id;
		}
	}

	/// <summary>
	/// Adds license points to the driver after they have been given a penalty that includes license points
	/// </summary>
	/// <param name="points">License points to be added to the driver</param>
	/// <exception cref="ArgumentException">If the number of points trying to be added plus the existent license
	/// points is greater than the maximum number of license points.
	/// </exception>

	public void AddLicensePoints(int points)
	{
		if(!CanAddLicensePoints(points))
		{
			throw new ArgumentException($"The driver can not have more than {MAX_LICENSE_POINTS} license points");
		}

		LicensePoints += points;
	}

	public bool CanAddLicensePoints(int points)
	{
		return !((points + LicensePoints) > MAX_LICENSE_POINTS);
	}

	private void CheckArguments(string name, DateOnly dateBirth, IDateTimeService dateTimeService)
	{
		if (dateBirth.CompareTo(DateOnly.FromDateTime(dateTimeService.Now().AddYears(-18))) > 0)
		{
			throw new ArgumentException("A driver must be over 18");
		}
	}
}
