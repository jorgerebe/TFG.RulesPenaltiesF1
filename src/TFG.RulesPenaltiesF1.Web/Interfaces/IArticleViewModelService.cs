using TFG.RulesPenaltiesF1.Core.Entities;

namespace TFG.RulesPenaltiesF1.Web.Interfaces;

public interface IArticleViewModelService
{
   Task<List<Article>> GetArticlesAsync();
   Task<Article> GetByIdAsync(int id);
}
