using TFG.RulesPenaltiesF1.Core.Entities;

namespace TFG.RulesPenaltiesF1.Core.Interfaces.Services;
public interface IArticleService
{
   Task CreateArticleAsync(Article article);
}
