using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TFG.RulesPenaltiesF1.Web.ViewModels;

public class SeasonViewModel
{
   public int Id { get; set; }

   [Required]
   public int Year { get; set; }

   [Required]
	[MinLength(3, ErrorMessage ="There must be at least three competitors")]
   public List<int> Competitors { get; set; } = new();

   public List<CompetitorViewModel> CompetitorsContent { get; set; } = new();


   [Required]
   [MinLength(2)]
   public List<CompetitionViewModel> Competitions { get; set; } = new();

   [Required]
	[DisplayName("Regulation")]
   public int RegulationId { get; set; } = new();


   public RegulationViewModel? Regulation { get; set; }


}
