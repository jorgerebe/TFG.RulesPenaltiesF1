using TFG.RulesPenaltiesF1.Core.Entities;

namespace TFG.RulesPenaltiesF1.Core.Interfaces.Repositories;
public interface ICircuitRepository : IRepository<Circuit>
{
   Task<List<Circuit>> GetAllCircuits();
   Task<Circuit?> GetCircuitById(int id);
   Task<Circuit?> GetCircuitByName(string name);
}
