using TFG.RulesPenaltiesF1.Core.Entities.RegulationAggregate;
using TFG.RulesPenaltiesF1.Core.Interfaces.Repositories;
using TFG.RulesPenaltiesF1.Web.Interfaces;
using TFG.RulesPenaltiesF1.Web.ViewModels;
using TFG.RulesPenaltiesF1.Web.ViewModels.Penalties;

namespace TFG.RulesPenaltiesF1.Web.Services;

public class RegulationViewModelService : IRegulationViewModelService
{
   private readonly IRegulationRepository _repository;
   private readonly IArticleViewModelService _articleViewModelService;

   public RegulationViewModelService(IRegulationRepository repository, IArticleViewModelService articleViewModelService)
   {
      _repository = repository;
      _articleViewModelService = articleViewModelService;
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
         articles.Add(_articleViewModelService.MapEntityToViewModel(article.Article!)!);
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
