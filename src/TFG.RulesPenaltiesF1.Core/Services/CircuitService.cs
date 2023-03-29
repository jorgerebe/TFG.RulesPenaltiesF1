using TFG.RulesPenaltiesF1.Core.Entities;
using TFG.RulesPenaltiesF1.Core.Interfaces.Repositories;
using TFG.RulesPenaltiesF1.Core.Interfaces.Services;

namespace TFG.RulesPenaltiesF1.Core.Services;
public class CircuitService : ICircuitService
{
   private readonly IRepository<Circuit> _repository;

   public CircuitService(IRepository<Circuit> repository)
   {
      _repository = repository;
   }

   public async Task CreateCircuitAsync(Circuit circuit)
   {
      ArgumentNullException.ThrowIfNull(circuit);

      await _repository.Add(circuit);
   }
}
