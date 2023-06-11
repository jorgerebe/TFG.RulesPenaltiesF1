namespace TFG.RulesPenaltiesF1.Core.Entities.CompetitionAggregate.Events;

public class CompetitionStartedEvent : DomainEventBase
{
	public Competition Competition { get; set; }

	public CompetitionStartedEvent(Competition competition)
	{
		Competition = competition;
	}
}
