namespace TFG.RulesPenaltiesF1.Core.Entities.SeasonAggregate;

public class SeasonCompetitor
{
   public Season? Season { get; set; }
   public int SeasonId { get; set; }

   public Competitor? Competitor { get; set; }
   public int CompetitorId { get; set; }

   public SeasonCompetitor(Season season, Competitor competitor)
   {
      Season = season;
      SeasonId = season.Id;

      Competitor = competitor;
      CompetitorId = competitor.Id;
   }

   public SeasonCompetitor(int seasonId, int competitorId)
   {
      SeasonId = seasonId;
      CompetitorId = competitorId;
   }
}
