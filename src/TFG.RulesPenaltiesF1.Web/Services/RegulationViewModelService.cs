using TFG.RulesPenaltiesF1.Core.Entities.RegulationAggregate;
using TFG.RulesPenaltiesF1.Core.Interfaces.Repositories;
using TFG.RulesPenaltiesF1.Web.Interfaces;
using TFG.RulesPenaltiesF1.Web.ViewModels;
using TFG.RulesPenaltiesF1.Web.ViewModels.Penalties;

namespace TFG.RulesPenaltiesF1.Web.Services;

public class RegulationViewModelService : IRegulationViewModelService
{
   private readonly IRegulationRepository _repository;

   public RegulationViewModelService(IRegulationRepository repository)
   {
      _repository = repository;
   }

   public async Task<RegulationViewModel?> GetRegulationByIdAsync(int id)
   {
      var regulation = await _repository.GetRegulationByIdAsync(id);

      if(regulation is null)
      {
         return null;
      }

      List<ArticleViewModel> articles = new();
      
      foreach(var article in regulation.Articles)
      {
         articles.Add(ArticleViewModel.MapEntityToViewModel(article.Article!)!);
      }

      List<PenaltyViewModel> penalties = new();
      
      foreach(var penalty in regulation.Penalties)
      {
         penalties.Add(PenaltyViewModelFactory.CreateViewModel(penalty.Penalty!));
      }

      return new RegulationViewModel()
      {
         Id = regulation.Id,
         Name = regulation.Name,
         ArticlesContent = articles,
         PenaltiesContent = penalties
      };
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
}
