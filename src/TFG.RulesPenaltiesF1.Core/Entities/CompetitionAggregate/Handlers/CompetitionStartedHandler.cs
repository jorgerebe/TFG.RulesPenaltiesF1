using MediatR;
using TFG.RulesPenaltiesF1.Core.Entities.CompetitionAggregate.Events;
using TFG.RulesPenaltiesF1.Core.Entities.IncidentAggregate;
using TFG.RulesPenaltiesF1.Core.Entities.Penalties;
using TFG.RulesPenaltiesF1.Core.Interfaces.Repositories;

namespace TFG.RulesPenaltiesF1.Core.Entities.CompetitionAggregate.Handlers;

public class CompetitionStartedHandler : INotificationHandler<CompetitionStartedEvent>
{
	private readonly IDriverRepository _driverRepository;
	private readonly IIncidentRepository _incidentRepository;

	public CompetitionStartedHandler(IDriverRepository driverRepository, IIncidentRepository incidentRepository)
	{
		_driverRepository = driverRepository;
		_incidentRepository = incidentRepository;
	}

	public async Task Handle(CompetitionStartedEvent notification, CancellationToken cancellationToken)
	{
		Competition competition = notification.Competition;

		List<Driver> driversChanged = new();

		List<Driver> driversWithTwelvePointsNoPenaltyLastCompetition = await _driverRepository.GetDriversWithTwelvePointsAndNoPenaltyLastCompetition(competition.Id);

		foreach(var driver in driversWithTwelvePointsNoPenaltyLastCompetition)
		{
			driver.LicensePoints = 0;
			driversChanged.Add(driver);
		}

		List<Driver> driversWithPenaltyPointsLessThanTwelve = await _driverRepository.GetDriversWithPenaltyPointsLessThanTwelve();
		List<Incident> incidentsLastTwelveMonths = await _incidentRepository.GetIncidentsWithPointsFromLastYearToCurrentWeek(competition.SeasonId, competition.Week);

		foreach(var driver in driversWithPenaltyPointsLessThanTwelve)
		{
			DateTime dateFrom = DateTime.MinValue;

			List<Incident> incidentsFromDriver = incidentsLastTwelveMonths.Where(i => i.Participation!.DriverId == driver.Id).ToList();
			 
			List<Incident> incidentsLimitLicensePoints = await _incidentRepository.GetIncidentsFromDriverMaximumLicensePoints(driver.Id);

			if (incidentsLimitLicensePoints.Count > 0)
			{
				dateFrom = incidentsLimitLicensePoints.Max(i => i.Created);
			}

			int sumLicensePoints = incidentsFromDriver.Where(i => i.Created > dateFrom).Sum(i => i.LicensePoints is null ? 0 : (int)i.LicensePoints);
			driver.LicensePoints = sumLicensePoints % 12;
			driversChanged.Add(driver);
		}

		await _driverRepository.UpdateAll(driversChanged);
	}
}
