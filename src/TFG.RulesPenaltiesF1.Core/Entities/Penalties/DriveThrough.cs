﻿namespace TFG.RulesPenaltiesF1.Core.Entities.Penalties;
public class DriveThrough : Penalty
{
   public int ElapsedSeconds { get; set; }
   protected DriveThrough() { }

   public DriveThrough(PenaltyType penaltyType, int elapsedSeconds, bool shown) : base(penaltyType, shown)
   {
      ElapsedSeconds = elapsedSeconds;
   }
}
