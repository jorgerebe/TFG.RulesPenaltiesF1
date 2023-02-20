using TFG.RulesPenaltiesF1.Core.Entities;
using TFG.RulesPenaltiesF1.Core.Interfaces;
using TFG.RulesPenaltiesF1.Web.Interfaces;

namespace TFG.RulesPenaltiesF1.Web.Services;

public class ArticleViewModelService : IArticleViewModelService
{
   private IRepository<Article> _articleRepository;

   public ArticleViewModelService(IRepository<Article> articleRepository)
   {
      _articleRepository= articleRepository;
   }

   public Task<List<Article>> GetArticlesAsync()
   {
      throw new NotImplementedException();
   }

   public Task<Article> GetByIdAsync(int id)
   {
      throw new NotImplementedException();
   }
}
