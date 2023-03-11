using TFG.RulesPenaltiesF1.Core.Entities.Penalties;

namespace TFG.RulesPenaltiesF1.Core.Interfaces;
public interface IPenaltyRepository
{
   Task<List<Penalty>> GetAllPenalties();
}
