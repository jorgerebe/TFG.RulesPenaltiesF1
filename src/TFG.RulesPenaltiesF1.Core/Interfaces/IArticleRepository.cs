using TFG.RulesPenaltiesF1.Core.Entities;

namespace TFG.RulesPenaltiesF1.Core.Interfaces;
public interface IArticleRepository : IRepository<Article>
{
   Task<List<Article>> GetTopLevelArticles();

   Task<Article?> GetArticleById(int id);
}
