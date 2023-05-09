using Ardalis.SmartEnum;

namespace TFG.RulesPenaltiesF1.Core.Entities.CompetitionAggregate;

public sealed class CompetitionStateEnum : SmartEnum<CompetitionStateEnum>
{
	public static readonly CompetitionStateEnum NotStarted = new ("Not Started", 1);
	public static readonly CompetitionStateEnum Started = new ("Started", 2);
	public static readonly CompetitionStateEnum Finished = new ("Finished", 3);

	private CompetitionStateEnum(string name, int value) : base(name, value)
	{
	}
}
