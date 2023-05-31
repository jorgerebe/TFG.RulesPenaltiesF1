namespace TFG.RulesPenaltiesF1.Core.Entities.IncidentAggregate.Events;

public class IncidentAddedEvent : DomainEventBase
{
	public Incident Incident { get; set; }

	public IncidentAddedEvent(Incident incident)
	{
		Incident = incident;
	}
}
