using TFG.RulesPenaltiesF1.Core.Interfaces;

namespace TFG.RulesPenaltiesF1.Core.Entities.RegulationAggregate;
public class Regulation : EntityBase, IAggregateRoot
{
   public int Year { get; set; }

   private readonly List<RegulationArticle> _articles = new();
   public IReadOnlyCollection<RegulationArticle> Articles => _articles.AsReadOnly();

   public Regulation(int year)
   {

   }

   public Regulation(int year, List<RegulationArticle> articles)
   {
      Year = year;
      _articles = articles;
   }

   public void AddArticle(Article article)
   {
      if(article is null)
      {
         throw new ArgumentNullException(nameof(article));
      }

      _articles.Add(new RegulationArticle(this, article));
   }

   public void RemoveArticle(Article article)
   {
      if (article is null)
      {
         throw new ArgumentNullException(nameof(article));
      }

      var regulationArticleToRemove = _articles.Find(x => x.Article == article);

      if(regulationArticleToRemove != null)
      {
         _articles.Remove(regulationArticleToRemove);
      }
   }
}
