namespace TFG.RulesPenaltiesF1.Core.Entities.Penalties;
public class Disqualification : Penalty
{
   public DisqualificationTypeEnum Type { get; set; }

   protected Disqualification() { Type = DisqualificationTypeEnum.Current; }

   public Disqualification(PenaltyType penaltyType, DisqualificationTypeEnum type, bool shown) : base(penaltyType, shown)
   {
		Type = type;
   }
}
