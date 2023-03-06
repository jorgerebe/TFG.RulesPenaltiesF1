using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFG.RulesPenaltiesF1.Core.Entities.Penalties;
public class Fine : Penalty
{

   protected Fine() { }
   public Fine(PenaltyType penaltyType) : base(penaltyType)
   {
   }
}
