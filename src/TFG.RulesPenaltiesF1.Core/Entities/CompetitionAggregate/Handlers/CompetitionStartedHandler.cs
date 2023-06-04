using MediatR;
using TFG.RulesPenaltiesF1.Core.Entities.CompetitionAggregate.Events;
using TFG.RulesPenaltiesF1.Core.Entities.IncidentAggregate;
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

		List<Driver> driversWithTwelvePointsNoPenaltyLastCompetition = await _driverRepository.GetDriversWithTwelvePointsAndNoPenaltyLastCompetition(competition.Id);

		foreach(var driver in driversWithTwelvePointsNoPenaltyLastCompetition)
		{
			driver.LicensePoints = 0;
		}

		await _driverRepository.UpdateAll(driversWithTwelvePointsNoPenaltyLastCompetition);

		List<Driver> driversWithPenaltyPointsLessThanTwelve = await _driverRepository.GetDriversWithPenaltyPointsLessThanTwelve();
		List<Incident> incidentsLastTwelveMonths = await _incidentRepository.GetIncidentsWithPointsFromLastYearToCurrentWeek(competition.SeasonId, competition.Week);



		Console.WriteLine("pepe");
	}
}
