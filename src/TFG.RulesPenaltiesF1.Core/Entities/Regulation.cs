using TFG.RulesPenaltiesF1.Core.Entities.Penalties;
using TFG.RulesPenaltiesF1.Core.Interfaces;

namespace TFG.RulesPenaltiesF1.Core.Entities;
public class Regulation : EntityBase, IAggregateRoot
{
   public int Year { get; set; }
   private readonly List<Article> _articles = new();
   private readonly List<Penalty> _penalties = new();

   public IReadOnlyCollection<Article> Articles => _articles.AsReadOnly();
   public IReadOnlyCollection<Penalty> Penalties => _penalties.AsReadOnly();

   public Regulation(int year)
   {

   }

   public Regulation(int year, List<Article> articles, List<Penalty> penalties)
   {
      Year = year;
      _articles = articles;
      _penalties = penalties;
   }
}
