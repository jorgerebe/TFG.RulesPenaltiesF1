namespace TFG.RulesPenaltiesF1.Core.Entities.RegulationAggregate;
public class RegulationArticle
{
   public int RegulationId { get; private set; }
   public Regulation? Regulation { get; private set; }

   public int ArticleId { get; private set; }
   public Article? Article { get; private set; }

   protected RegulationArticle(int regulationId, int articleId)
   {
      RegulationId = regulationId;
      ArticleId = articleId;
   }

   public RegulationArticle(Regulation regulation, Article article)
   {
      if(regulation is null || article is null)
      {
         throw new ArgumentException("There must be a regulation and an article");
      }

      Regulation = regulation;
      RegulationId = regulation.Id;
      Article = article;
      ArticleId = article.Id;
   }
}
