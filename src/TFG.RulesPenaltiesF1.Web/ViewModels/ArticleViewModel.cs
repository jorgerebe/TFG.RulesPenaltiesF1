using System.ComponentModel.DataAnnotations;
namespace TFG.RulesPenaltiesF1.Web.ViewModels;

public class ArticleViewModel
{
   public int Id { get; set; }

   [Required]
   [StringLength(500, MinimumLength = 20, ErrorMessage ="Maximum size: 500 chars. Minimum length: 20 chars")]
   [DataType(DataType.Text)]
   public string? Content { get; set; }
   public List<ArticleViewModel> SubArticles { get; set; } = new();
}
