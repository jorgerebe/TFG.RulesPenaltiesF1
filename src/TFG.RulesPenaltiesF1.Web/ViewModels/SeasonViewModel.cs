using System.ComponentModel.DataAnnotations;

namespace TFG.RulesPenaltiesF1.Web.ViewModels;

public class SeasonViewModel
{
   public int Id { get; set; }

   [Required]
   public int Year { get; set; }

   [Required]
   [MinLength(3)]
   public List<CompetitorViewModel> Competitors { get; set; } = new();   

   [Required]
   [MinLength(2)]
   public List<CompetitionViewModel> Competitions { get; set; } = new();

   [Required]
   public int RegulationId { get; set; } = new();

   public RegulationViewModel Regulation { get; set; } = new();


}
