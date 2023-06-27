using TFG.RulesPenaltiesF1.Core.Interfaces;

namespace TFG.RulesPenaltiesF1.Core.Entities.Penalties;

/// <summary>
/// Class <c>PenaltyType</c> models the type of a penalty: name, description and if a fine or license points
/// can be applied.
/// </summary>

public class PenaltyType : EntityBase, IAggregateRoot
{
	public string Name { get; private set; }
	public string Description { get; private set; }
	public bool PenaltyPoints { get; private set; }
	public bool Fine { get; private set; }

	internal PenaltyType(int id)
	{
		Name = "";
		Description = "";
		Id = id;
	}

	public PenaltyType(string name, string description, bool penaltyPoints, bool fine)
	{
		Name = name;
		Description = description;
		PenaltyPoints = penaltyPoints;
		Fine = fine;
	}
}
