using System.ComponentModel.DataAnnotations;
namespace TFG.RulesPenaltiesF1.Web.ViewModels;

public class ArticleViewModel
{
   [Required]
   [StringLength(1000, MinimumLength = 20, ErrorMessage ="Maximum size: 1000 chars. Minimum length: 20 chars")]
   [DataType(DataType.Text)]
   public string? Content { get; set; }
   public List<ArticleViewModel> Articles { get; set; } = new();
}
