using TFG.RulesPenaltiesF1.Core.Entities.RegulationAggregate;
using TFG.RulesPenaltiesF1.Core.Interfaces;
using TFG.RulesPenaltiesF1.Web.Interfaces;
using TFG.RulesPenaltiesF1.Web.ViewModels;

namespace TFG.RulesPenaltiesF1.Web.Services;

public class RegulationViewModelService : IRegulationViewModelService
{
   private readonly IPenaltyRepository<Regulation> _repository;

   public RegulationViewModelService(IPenaltyRepository<Regulation> repository)
   {
      _repository = repository;
   }

   public Task<RegulationViewModel?> GetRegulationByIdAsync(int id)
   {
      throw new NotImplementedException();
   }

   public async Task<List<RegulationViewModel>> GetRegulationsAsync()
   {
      var regulations = await _repository.GetAllAsync();

      return new List<RegulationViewModel>();
   }

   public Regulation? MapViewModelToEntity(RegulationViewModel article)
   {
      throw new NotImplementedException();
   }
}
