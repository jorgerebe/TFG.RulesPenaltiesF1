using TFG.RulesPenaltiesF1.Core.Interfaces;

namespace TFG.RulesPenaltiesF1.Core.Entities.Penalties;
public class PenaltyType : EntityBase, IAggregateRoot
{
	public string Name { get; private set; }
	public string Description { get; private set; }

	internal PenaltyType(int id)
	{
		Name = "";
		Description = "";
		Id = id;
	}

	public PenaltyType(string name, string description)
	{
		Name = name;
		Description = description;
	}
}
