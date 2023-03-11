using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFG.RulesPenaltiesF1.Core.Entities;
using TFG.RulesPenaltiesF1.Core.Interfaces;
using TFG.RulesPenaltiesF1.Core.Interfaces.Services;

namespace TFG.RulesPenaltiesF1.Core.Services;
public class ArticleService : IArticleService
{
   private readonly IPenaltyRepository<Article> _repository;

   public ArticleService(IPenaltyRepository<Article> repository)
   {
      _repository = repository;
   }

   public async Task CreateArticleAsync(Article article)
   {
      ArgumentNullException.ThrowIfNull(article);

      await _repository.Add(article);
   }
}
