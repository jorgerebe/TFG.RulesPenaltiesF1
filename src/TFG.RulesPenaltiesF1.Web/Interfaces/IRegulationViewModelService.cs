using TFG.RulesPenaltiesF1.Core.Entities.RegulationAggregate;
using TFG.RulesPenaltiesF1.Web.ViewModels;

namespace TFG.RulesPenaltiesF1.Web.Interfaces;

public interface IRegulationViewModelService
{
   Task<List<RegulationViewModel>> GetRegulationsAsync();
   Task<RegulationViewModel?> GetRegulationByIdAsync(int id);
   Task<RegulationViewModel?> GetRegulationByCompetitionId(int id);

   Task<bool> ExistsRegulationWithName(string name);
}
