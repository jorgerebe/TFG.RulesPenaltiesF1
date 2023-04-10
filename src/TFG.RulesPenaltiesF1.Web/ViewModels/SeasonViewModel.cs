using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TFG.RulesPenaltiesF1.Web.ViewModels;

public class SeasonViewModel
{
   public int Id { get; set; }

   [Required]
	[Range(1950, 2100, ErrorMessage ="A season must be on or before 2100 and on or after 1950")]
   public int Year { get; set; }

   [Required]
	[MinLength(2, ErrorMessage ="There must be at least two competitors")]
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
