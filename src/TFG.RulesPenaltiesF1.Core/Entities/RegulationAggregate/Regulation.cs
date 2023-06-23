using TFG.RulesPenaltiesF1.Core.Entities.Penalties;
using TFG.RulesPenaltiesF1.Core.Interfaces;

namespace TFG.RulesPenaltiesF1.Core.Entities.RegulationAggregate;
public class Regulation : EntityBase, IAggregateRoot
{
	public string Name { get; set; } = string.Empty;

   private readonly List<RegulationArticle> _articles = new();
   public IReadOnlyCollection<RegulationArticle> Articles => _articles.AsReadOnly();

   private readonly List<RegulationPenalty> _penalties = new();
   public IReadOnlyCollection<RegulationPenalty> Penalties => _penalties.AsReadOnly();

	private Regulation()
	{

	}

	public Regulation(int id)
	{
		Id = id;
	}

	public Regulation(string name)
   {
      Name = name;
   }

   public Regulation(string name, List<RegulationArticle> articles, List<RegulationPenalty> penalties)
   {
      Name = name;
      _articles = articles;
      _penalties = penalties;
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
   public void AddPenalty(Penalty penalty)
   {
      if(penalty is null)
      {
         throw new ArgumentNullException(nameof(penalty));
      }

      _penalties.Add(new RegulationPenalty(this, penalty));
   }

   public void RemovePenalty(Penalty penalty)
   {
      if (penalty is null)
      {
         throw new ArgumentNullException(nameof(penalty));
      }

      var regulationArticleToRemove = _penalties.Find(x => x.Penalty == penalty);

      if(regulationArticleToRemove != null)
      {
         _penalties.Remove(regulationArticleToRemove);
      }
   }
}
