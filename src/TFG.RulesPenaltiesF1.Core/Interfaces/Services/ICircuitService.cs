using TFG.RulesPenaltiesF1.Core.Entities;

namespace TFG.RulesPenaltiesF1.Core.Interfaces.Services;
public interface ICircuitService
{
   Task CreateCircuitAsync(Circuit circuit);
}
