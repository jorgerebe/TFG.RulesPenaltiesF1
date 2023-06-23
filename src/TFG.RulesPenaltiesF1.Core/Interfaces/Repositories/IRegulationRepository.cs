using TFG.RulesPenaltiesF1.Core.Entities.RegulationAggregate;

namespace TFG.RulesPenaltiesF1.Core.Interfaces.Repositories;
public interface IRegulationRepository : IRepository<Regulation>
{
   Task<bool> ExistsRegulationByName(string name);

   Task<Regulation?> GetRegulationByIdAsync(int id);
   Task<Regulation?> GetRegulationByCompetitionId(int competitionId);
}
