using Ardalis.SmartEnum;

namespace TFG.RulesPenaltiesF1.Core.Entities.CompetitionAggregate;

public class SessionStateEnum : SmartEnum<SessionStateEnum>
{
	public static readonly SessionStateEnum NotStarted = new("Not Started", 1);
	public static readonly SessionStateEnum Started = new("Started", 2);
	public static readonly SessionStateEnum Finished = new("Finished", 3);

	public SessionStateEnum(string name, int value) : base(name, value)
	{
	}
}
