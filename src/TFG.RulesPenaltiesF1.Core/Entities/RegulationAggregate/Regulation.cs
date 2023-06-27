using TFG.RulesPenaltiesF1.Core.Entities.Penalties;
using TFG.RulesPenaltiesF1.Core.Interfaces;

namespace TFG.RulesPenaltiesF1.Core.Entities.RegulationAggregate;

/// <summary>
/// The class <c>Regulation</c> models a regulation that could be used in a season, that includes
/// a list of penalties and articles, at least one of each.
/// </summary>

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

	public Regulation(string name)
	{
		Name = name;
	}

	public Regulation(string name, List<RegulationArticle> articles, List<RegulationPenalty> penalties)
   {
      Name = name;

		ArgumentException.ThrowIfNullOrEmpty(name);
		ArgumentNullException.ThrowIfNull(articles);
		ArgumentNullException.ThrowIfNull(penalties);

		if(articles.Count == 0 || penalties.Count == 0)
		{
			throw new ArgumentException("There must be at least an article and a penalty in a regulation");
		}

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
		if(_articles.Count <= 1)
		{
			throw new ArgumentException("There must be at least an article and a penalty in a regulation");
		}

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
		if (penalty is null)
      {
         throw new ArgumentNullException(nameof(penalty));
      }

      _penalties.Add(new RegulationPenalty(this, penalty));
   }

   public void RemovePenalty(Penalty penalty)
   {
		if (_penalties.Count <= 1)
		{
			throw new ArgumentException("There must be at least an article and a penalty in a regulation");
		}

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
