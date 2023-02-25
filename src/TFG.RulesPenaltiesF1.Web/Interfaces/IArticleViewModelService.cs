using TFG.RulesPenaltiesF1.Core.Entities;
using TFG.RulesPenaltiesF1.Web.ViewModels;

namespace TFG.RulesPenaltiesF1.Web.Interfaces;

public interface IArticleViewModelService
{
   Task<List<ArticleViewModel>> GetArticlesAsync();
   Task<ArticleViewModel?> GetByIdAsync(int id);

   Article? MapViewModelToEntity(ArticleViewModel article);
}
