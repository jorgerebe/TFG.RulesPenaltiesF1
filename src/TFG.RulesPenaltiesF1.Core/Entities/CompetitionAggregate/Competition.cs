using TFG.RulesPenaltiesF1.Core.Interfaces;

namespace TFG.RulesPenaltiesF1.Core.Entities.CompetitionAggregate;

public class Competition : EntityBase, IAggregateRoot
{
	public Season? Season { get; set; }
	public int SeasonId { get; set; }

	public Circuit? Circuit { get; set; }
	public int CircuitId { get; set; }

	public CompetitionStateEnum CompetitionState { get; set; }

	public string Name { get; set; } = string.Empty;
	public bool IsSprint { get; set; }
	public int Week { get; set; }

	public Competition(Circuit circuit, string name, bool isSprint, int week)
	{
		ArgumentNullException.ThrowIfNull(circuit, nameof(circuit));
		ArgumentException.ThrowIfNullOrEmpty(name, nameof(name));

		Circuit = circuit;
		CircuitId = circuit.Id;

		Name = name;
		IsSprint = isSprint;
		Week = week;
		CompetitionState = CompetitionStateEnum.NotStarted;
	}

	public Competition(int circuitId, string name, bool isSprint, int week)
	{
		ArgumentException.ThrowIfNullOrEmpty(name, nameof(name));

		CircuitId = circuitId;

		Name = name;
		IsSprint = isSprint;
		Week = week;
		CompetitionState = CompetitionStateEnum.NotStarted;
	}

	public void StartCompetition()
	{
		if (!CompetitionState.Equals(CompetitionStateEnum.NotStarted))
		{
			throw new InvalidOperationException();
		}

		CompetitionState = CompetitionStateEnum.Started;
	}
}
