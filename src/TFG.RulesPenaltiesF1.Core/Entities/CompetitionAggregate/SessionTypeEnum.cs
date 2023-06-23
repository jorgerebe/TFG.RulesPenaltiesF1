using Ardalis.SmartEnum;

namespace TFG.RulesPenaltiesF1.Core.Entities.CompetitionAggregate;

public class SessionTypeEnum : SmartEnum<SessionTypeEnum>
{
	public static readonly SessionTypeEnum Practice = new("Practice", 1);
	public static readonly SessionTypeEnum Qualifying = new("Qualifying", 2);
	public static readonly SessionTypeEnum SprintShootout = new("Sprint Shootout", 3);
	public static readonly SessionTypeEnum Sprint = new("Sprint", 4);
	public static readonly SessionTypeEnum Race = new("Race", 5);

	public SessionTypeEnum(string name, int value) : base(name, value)
	{
	}
}
