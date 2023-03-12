using TFG.RulesPenaltiesF1.Core.Entities.RegulationAggregate;
using TFG.RulesPenaltiesF1.Core.Interfaces;
using TFG.RulesPenaltiesF1.Web.Interfaces;
using TFG.RulesPenaltiesF1.Web.ViewModels;

namespace TFG.RulesPenaltiesF1.Web.Services;

public class RegulationViewModelService : IRegulationViewModelService
{
   private readonly IRegulationRepository _repository;

   public RegulationViewModelService(IRegulationRepository repository)
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

      var regulationsViewModel = new List<RegulationViewModel>();

      foreach(var regulation in regulations)
      {
         regulationsViewModel.Add(new RegulationViewModel()
         {
            Id = regulation.Id,
            Name = regulation.Name
         });
      }

      return regulationsViewModel;
   }

   public async Task<bool> ExistsRegulationWithName(string name)
   {
      return await _repository.ExistsRegulationByName(name);
   }

   public Regulation? MapViewModelToEntity(RegulationViewModel regulation)
   {
      if(regulation is null)
      {
         return null;
      }

      List<RegulationArticle> regulationArticles = new();

      foreach(int id in regulation.Articles)
      {
         regulationArticles.Add(new RegulationArticle(0, id));
      }
      
      List<RegulationPenalty> regulationPenalties = new();

      foreach(int id in regulation.Penalties)
      {
         regulationPenalties.Add(new RegulationPenalty(0, id));
      }

      var regulationEntity = new Regulation(regulation.Name, regulationArticles, regulationPenalties);

      return regulationEntity;
   }
}
