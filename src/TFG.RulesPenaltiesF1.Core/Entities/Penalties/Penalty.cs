using TFG.RulesPenaltiesF1.Core.Interfaces;

namespace TFG.RulesPenaltiesF1.Core.Entities.Penalties;

/// <summary>
/// Class <c>Penalty</c> models a Penalty of a regulation
/// </summary>

public abstract class Penalty : EntityBase, IAggregateRoot
{
   public int PenaltyTypeId { get; set; }

   public PenaltyType PenaltyType { get; set; } = new PenaltyType(-1);

	//Attribute Shown indicates if the penalty can be part of a regulation. For example: there is a penalty
	//that indicates the suspension of a driver for getting to the limit of 12 license points. That will not
	//be part of a regulation, as it is applied automatically.
	public bool Shown { get; set; }
   public string? Discriminator { get; set; }

   protected Penalty() { }

   public Penalty(PenaltyType penaltyType, bool shown)
   {
      PenaltyType = penaltyType;
		Shown = shown;
   }
}
