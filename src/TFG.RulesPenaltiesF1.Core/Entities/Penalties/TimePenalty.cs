﻿namespace TFG.RulesPenaltiesF1.Core.Entities.Penalties;
public class TimePenalty : Penalty
{
   public int Seconds { get; set; }

   protected TimePenalty() { }

   public TimePenalty(PenaltyType penaltyType, int seconds, bool shown) : base(penaltyType, shown)
   {
      Seconds = seconds;
   }
}
