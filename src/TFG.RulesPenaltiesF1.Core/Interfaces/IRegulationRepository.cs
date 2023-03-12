using TFG.RulesPenaltiesF1.Core.Entities.RegulationAggregate;

namespace TFG.RulesPenaltiesF1.Core.Interfaces;
public interface IRegulationRepository : IRepository<Regulation>
{
   Task<bool> ExistsRegulationByName(string name);
}
