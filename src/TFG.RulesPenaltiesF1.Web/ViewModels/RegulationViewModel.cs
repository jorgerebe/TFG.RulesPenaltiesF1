using System.ComponentModel.DataAnnotations;
using TFG.RulesPenaltiesF1.Web.ViewModels.Penalties;

namespace TFG.RulesPenaltiesF1.Web.ViewModels;

public class RegulationViewModel
{
   public int Id { get; set; }

   public int Year { get; set; }

   [Required]
   [MinLength(1, ErrorMessage ="There must be at least one article in the regulations")]
   public List<int> Articles { get; set; } = new();
   
   [Required]
   [MinLength(1, ErrorMessage ="There must be at least one penalty in the regulations")]
   public List<int> Penalties { get; set; } = new();

   public List<ArticleViewModel> ArticlesContent { get; set; } = new();
   public List<PenaltyViewModel> PenaltiesContent { get; set; } = new();
}
