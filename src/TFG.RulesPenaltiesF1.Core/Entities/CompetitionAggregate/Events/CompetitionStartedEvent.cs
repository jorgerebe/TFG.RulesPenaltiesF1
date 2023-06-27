namespace TFG.RulesPenaltiesF1.Core.Entities.CompetitionAggregate.Events;

/// <summary>
/// Class <c>CompetitionStartedEvent</c> models an event that triggers when a competition is started, and
/// updates the drivers license points.
/// </summary>

public class CompetitionStartedEvent : DomainEventBase
{
	public Competition Competition { get; set; }

	public CompetitionStartedEvent(Competition competition)
	{
		Competition = competition;
	}
}
