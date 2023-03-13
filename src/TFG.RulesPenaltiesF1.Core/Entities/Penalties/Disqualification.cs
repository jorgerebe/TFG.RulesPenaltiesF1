namespace TFG.RulesPenaltiesF1.Core.Entities.Penalties;
public class Disqualification : Penalty
{
   public bool NextCompetition { get; set; }

   protected Disqualification() { }

   public Disqualification(PenaltyType penaltyType, bool nextCompetition) : base(penaltyType)
   {
      NextCompetition = nextCompetition;
   }
}
