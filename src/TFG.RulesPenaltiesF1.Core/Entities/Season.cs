using TFG.RulesPenaltiesF1.Core.Entities.RegulationAggregate;
using TFG.RulesPenaltiesF1.Core.Interfaces;

namespace TFG.RulesPenaltiesF1.Core.Entities;

public class Season : EntityBase, IAggregateRoot
{
   public int Year { get; set; }

   private readonly List<Competitor> _competitors = new();
   public IReadOnlyCollection<Competitor> Competitors => _competitors.AsReadOnly();

   private readonly List<Competition> _competitions = new();
   public IReadOnlyCollection<Competition> Competitions => _competitions.AsReadOnly();

   public int RegulationId { get; set; }
   public Regulation? Regulation { get; set; }

   private Season()
   {
      
   }

   public Season(int year, List<Competitor> competitors, List<Competition> competitions, Regulation regulation)
   {
      Year = year;

      if (competitors is null || competitors.Count == 0)
      {
         throw new ArgumentException("There must be at least 3 competitors");
      }
      _competitors = competitors;

      if (competitions is null || competitions.Count == 0)
      {
         throw new ArgumentException("There must be at least 2 competitions");
      }
      _competitions = competitions;

      ArgumentNullException.ThrowIfNull(regulation);
      Regulation = regulation;
      RegulationId = Regulation.Id;
   }

   public Season(int year, List<Competitor> competitors, List<Competition> competitions, int regulationId)
   {
      Year = year;

      if (competitors is null || competitors.Count == 0)
      {
         throw new ArgumentException("There must be at least 3 competitors");
      }
      _competitors = competitors;

      if (competitions is null || competitions.Count == 0)
      {
         throw new ArgumentException("There must be at least 2 competitions");
      }
      _competitions = competitions;

      RegulationId = regulationId;
   }
}
