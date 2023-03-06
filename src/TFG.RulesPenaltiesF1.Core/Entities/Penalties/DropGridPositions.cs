using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFG.RulesPenaltiesF1.Core.Entities.Penalties;
public class DropGridPositions : Penalty
{
   public int? Positions { get; set; }

   protected DropGridPositions() { }

   public DropGridPositions(PenaltyType penaltyType, int? positions) : base(penaltyType)
   {
      Positions = positions;
   }
}
