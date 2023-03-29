using TFG.RulesPenaltiesF1.Core.Entities;

namespace TFG.RulesPenaltiesF1.Core.Interfaces.Repositories;
public interface ICircuitRepository
{
   Task<List<Circuit>> GetAllCircuits();
   Task<Circuit?> GetCircuitById(int id);
}
