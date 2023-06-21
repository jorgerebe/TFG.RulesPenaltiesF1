using MediatR;
using TFG.RulesPenaltiesF1.Core.Entities.IncidentAggregate.Events;
using TFG.RulesPenaltiesF1.Core.Entities.Penalties;
using TFG.RulesPenaltiesF1.Core.Interfaces;
using TFG.RulesPenaltiesF1.Core.Interfaces.Repositories;

namespace TFG.RulesPenaltiesF1.Core.Entities.IncidentAggregate.Handlers;

public class IncidentAddedHandler : INotificationHandler<IncidentAddedEvent>
{
	private readonly IDriverRepository _driverRepository;
	private readonly IDateTimeService _dateTimeService;
	private readonly IPenaltyRepository _penaltyRepository;
	private readonly IIncidentRepository _incidentRepository;

	public IncidentAddedHandler(IDriverRepository driverRepository, IDateTimeService dateTimeService, IPenaltyRepository penaltyRepository,
		IIncidentRepository incidentRepository)
	{
		_driverRepository = driverRepository;
		_dateTimeService = dateTimeService;
		_penaltyRepository = penaltyRepository;
		_incidentRepository = incidentRepository;
	}

	public async Task Handle(IncidentAddedEvent notification, CancellationToken cancellationToken)
	{
		var driver = await _driverRepository.GetDriverByParticipationId(notification.Incident.ParticipationId);

		if(driver is null)
		{
			throw new ArgumentException("Incident not valid");
		}

		Incident incidentEvent = notification.Incident;

		if(incidentEvent.LicensePoints is not null)
		{

			driver.AddLicensePoints((int)incidentEvent.LicensePoints);
			if(driver.LicensePoints == 12)
			{
				Penalty? penaltyLimitPoints = await _penaltyRepository.GetLimitLicensePointsPenalty();

				if(penaltyLimitPoints is null)
				{
					PenaltyType? suspension = await _penaltyRepository.GetPenaltyTypeByName("Suspension");
					if(suspension is null)
					{
						suspension = new PenaltyType("Suspension", "Suspension from the driver’s next Competition", true, false);
						await _penaltyRepository.AddPenaltyType(suspension);
					}
					penaltyLimitPoints = new Disqualification(suspension, DisqualificationTypeEnum.LicensePointsLimit, false);

					await _penaltyRepository.Add(penaltyLimitPoints);
				}

				Incident incident = new Incident(_dateTimeService.Now(), incidentEvent.ParticipationId, incidentEvent.SessionId,
					"Driver got to the limit of License Points", null, penaltyLimitPoints.Id, "Driver got to the limit of License Points",
					null, null);
				await _incidentRepository.Add(incident);
			}
		}

		await _driverRepository.Update(driver);
	}
}
