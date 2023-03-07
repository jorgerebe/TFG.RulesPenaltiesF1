using TFG.RulesPenaltiesF1.Core.Entities;
using TFG.RulesPenaltiesF1.Web.ViewModels;

namespace TFG.RulesPenaltiesF1.Web.Interfaces;

public interface IRegulationViewModelService
{
   Task<List<RegulationViewModel>> GetRegulationsAsync();
   Task<RegulationViewModel?> GetRegulationByIdAsync(int id);

   Regulation? MapViewModelToEntity(RegulationViewModel article);
}
