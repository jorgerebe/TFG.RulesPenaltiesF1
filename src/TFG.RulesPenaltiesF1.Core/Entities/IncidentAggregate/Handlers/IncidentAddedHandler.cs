using MediatR;
using TFG.RulesPenaltiesF1.Core.Entities.IncidentAggregate.Events;
using TFG.RulesPenaltiesF1.Core.Interfaces.Repositories;

namespace TFG.RulesPenaltiesF1.Core.Entities.IncidentAggregate.Handlers;

public class IncidentAddedHandler : INotificationHandler<IncidentAddedEvent>
{
	private readonly IDriverRepository _driverRepository;

	public IncidentAddedHandler(IDriverRepository driverRepository)
	{
		_driverRepository = driverRepository;
	}

	public async Task Handle(IncidentAddedEvent notification, CancellationToken cancellationToken)
	{
		var driver = await _driverRepository.GetDriverByParticipationId(notification.Incident.ParticipationId);

		if(driver is null)
		{
			throw new ArgumentException("Incident not valid");
		}

		if(notification.Incident.LicensePoints is not null)
		{
			driver.AddLicensePoints((int)notification.Incident.LicensePoints);
		}

		await _driverRepository.Update(driver);
	}
}
