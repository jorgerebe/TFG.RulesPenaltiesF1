using System.ComponentModel.DataAnnotations;

namespace TFG.RulesPenaltiesF1.Web.ViewModels;

public class ArticleViewModel
{
   public int Id { get; set; }

   [Required]
   [StringLength(500, MinimumLength = 10, ErrorMessage ="Maximum size: 500 chars. Minimum length: 10 chars")]
   [DataType(DataType.Text)]
   public string? Content { get; set; }

   public List<ArticleViewModel> SubArticles { get; set; } = new ();

   public ArticleViewModel()
   {

   }

   public ArticleViewModel(string content)
   {
      Content = content;
   }

   public override string ToString()
   {
      string output = "Article " + Id;
      
      if(SubArticles.Count > 0)
      {
         output += " and subarticles: --";
      }

      output += Content!;

      int i = 1;

      foreach(var item in SubArticles)
      {
         output += (" ----Subarticle " + i + "----\n\r" + "\t" + "*" + item.Content);
         i++;
      }

      return output;
   }

}
