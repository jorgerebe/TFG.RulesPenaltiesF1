using TFG.RulesPenaltiesF1.Core.Entities;
using TFG.RulesPenaltiesF1.Core.Interfaces;
using TFG.RulesPenaltiesF1.Core.Interfaces.Services;

namespace TFG.RulesPenaltiesF1.Core.Services;
public class ArticleService : IArticleService
{
   private readonly IRepository<Article> _repository;

   public ArticleService(IRepository<Article> repository)
   {
      _repository = repository;
   }

   public async Task CreateArticleAsync(Article article)
   {
      ArgumentNullException.ThrowIfNull(article);

      await _repository.Add(article);
   }
}
