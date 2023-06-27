namespace TFG.RulesPenaltiesF1.Core.Entities.IncidentAggregate.Events;

/// <summary>
/// Class <c>IncidentAddedEvent</c> models an event that happens when an incident is added and updates
/// the driver license points if it is necessary. If the driver gets over the 12 license points limit,
/// a suspension for the next competition is added.
/// </summary>

public class IncidentAddedEvent : DomainEventBase
{
	public Incident Incident { get; set; }

	public IncidentAddedEvent(Incident incident)
	{
		Incident = incident;
	}
}
