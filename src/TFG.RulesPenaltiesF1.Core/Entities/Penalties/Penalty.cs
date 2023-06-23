using TFG.RulesPenaltiesF1.Core.Interfaces;

namespace TFG.RulesPenaltiesF1.Core.Entities.Penalties;
public abstract class Penalty : EntityBase, IAggregateRoot
{
   public int PenaltyTypeId { get; set; }

   public PenaltyType PenaltyType { get; set; } = new PenaltyType(-1);
	public bool Shown { get; set; }
   public string? Discriminator { get; set; }

   protected Penalty() { }

   public Penalty(PenaltyType penaltyType, bool shown)
   {
      PenaltyType = penaltyType;
		Shown = shown;
   }
}
