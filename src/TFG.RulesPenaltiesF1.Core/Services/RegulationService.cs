using TFG.RulesPenaltiesF1.Core.Entities.RegulationAggregate;
using TFG.RulesPenaltiesF1.Core.Interfaces.Repositories;
using TFG.RulesPenaltiesF1.Core.Interfaces.Services;

namespace TFG.RulesPenaltiesF1.Core.Services;
public class RegulationService : IRegulationService
{
   private readonly IRepository<Regulation> _repository;

   public RegulationService(IRepository<Regulation> repository)
   {
      _repository = repository;
   }

   public async Task CreateRegulationAsync(Regulation regulation)
   {
      ArgumentNullException.ThrowIfNull(regulation);

      await _repository.Add(regulation);
   }
}
