﻿namespace TFG.RulesPenaltiesF1.Web.ViewModels.Penalties;

public class TimePenaltyViewModel : PenaltyViewModel
{
   public int Seconds { get; set; }

   public override string ToString()
   {
      return Name + ": " + Seconds + " seconds " + Description;
   }
}
