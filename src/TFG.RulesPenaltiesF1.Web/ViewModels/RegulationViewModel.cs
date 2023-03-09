using System.ComponentModel.DataAnnotations;

namespace TFG.RulesPenaltiesF1.Web.ViewModels;

public class RegulationViewModel
{
   public int Id { get; set; }

   public int Year { get; set; }

   [Required]
   [MinLength(1, ErrorMessage ="There must be at least one article in the regulations")]
   public List<ArticleViewModel> Articles { get; set; } = new();
   
   [Required]
   [MinLength(1, ErrorMessage ="There must be at least one penalty in the regulations")]
   public List<PenaltyViewModel> Penalties { get; set; } = new();
}
