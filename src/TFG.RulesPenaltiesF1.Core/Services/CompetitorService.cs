using TFG.RulesPenaltiesF1.Core.Entities;
using TFG.RulesPenaltiesF1.Core.Interfaces.Repositories;
using TFG.RulesPenaltiesF1.Core.Interfaces.Services;

namespace TFG.RulesPenaltiesF1.Core.Services;
public class CompetitorService : ICompetitorService
{
   private readonly IRepository<Competitor> _repository;

   public CompetitorService(IRepository<Competitor> repository)
   {
      _repository = repository;
   }

   public async Task CreateCompetitorAsync(Competitor competitor)
   {
      ArgumentNullException.ThrowIfNull(competitor);

      await _repository.Add(competitor);
   }
}
