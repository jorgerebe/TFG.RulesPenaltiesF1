using TFG.RulesPenaltiesF1.Core.Entities;
using TFG.RulesPenaltiesF1.Core.Interfaces;
using TFG.RulesPenaltiesF1.Web.Interfaces;
using TFG.RulesPenaltiesF1.Web.ViewModels;

namespace TFG.RulesPenaltiesF1.Web.Services;

public class ArticleViewModelService : IArticleViewModelService
{
   private IArticleRepository _articleRepository;

   public ArticleViewModelService(IArticleRepository articleRepository)
   {
      _articleRepository= articleRepository;
   }

   public async Task<List<ArticleViewModel>> GetArticlesAsync()
   {
      var articles = await _articleRepository.GetTopLevelArticles();

      List<ArticleViewModel> result = new List<ArticleViewModel>();

      foreach(var article in articles)
      {
         List<ArticleViewModel> subArticles = new();
         foreach (var subarticle in article.SubArticles)
         {
            subArticles.Add(new ArticleViewModel
            {
               Content = subarticle.Content
            });
         }

         result.Add(new ArticleViewModel()
         {
            Id = article.Id,
            Content = article.Content,
            SubArticles = subArticles
         });
      }

      return result;
   }

   public async Task<ArticleViewModel?> GetByIdAsync(int id)
   {
      var article = await _articleRepository.GetByIdAsync(id);

      if(article == null)
      {
         return null;
      }

      ArticleViewModel result = new ArticleViewModel()
      {
         Id = article.Id
      };

      return result;
   }
}
