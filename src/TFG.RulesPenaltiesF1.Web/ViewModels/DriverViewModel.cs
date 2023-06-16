using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TFG.RulesPenaltiesF1.Core.Entities;
using TFG.RulesPenaltiesF1.Core.Interfaces;

namespace TFG.RulesPenaltiesF1.Web.ViewModels;

public class DriverViewModel
{
	public int Id { get; set; }

	[Required]
	[MinLength(5, ErrorMessage ="The driver's name must have at least 5 chars length")]
	public string Name { get; set; } = string.Empty;

	[Required]
	[DisplayName("Date birth")]
	public DateOnly DateBirth { get; set; }

	[DisplayName("License Points")]
	public int LicensePoints { get; set; }

	[Required]
	[DisplayName("Competitor")]
	public int CompetitorId { get; set; }

	public CompetitorViewModel? Competitor { get; set; }

	public static DriverViewModel? MapEntityToViewModel(Driver driver)
	{
		if (driver is null)
		{
			return null;
		}

		DriverViewModel driverViewModel = new()
		{
			Id = driver.Id,
			Name = driver.Name,
			DateBirth = driver.DateBirth,
			LicensePoints = driver.LicensePoints,
			Competitor = driver.Competitor is not null ? new CompetitorViewModel() { Id = driver.Competitor!.Id, Name = driver.Competitor.Name } : null,
			CompetitorId = driver.CompetitorId is null ? -1 : (int)driver.CompetitorId
		};

		return driverViewModel;
	}

	public static Driver? MapViewModelToEntity(DriverViewModel driver, IDateTimeService dateTimeService)
	{
		if (driver is null)
		{
			return null;
		}

		Driver driverEntity;

		if (driver.CompetitorId == -1)
		{
			driverEntity = new Driver(driver.Name, driver.DateBirth, null, dateTimeService);
		}
		else
		{
			driverEntity = new Driver(driver.Name, driver.DateBirth, driver.CompetitorId, dateTimeService);
		}

		driverEntity.Id = driver.Id;
		return driverEntity;
	}
}
