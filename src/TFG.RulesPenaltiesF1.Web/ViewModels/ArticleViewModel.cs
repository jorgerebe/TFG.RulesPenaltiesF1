using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Html;
using System.Text;
using Microsoft.AspNetCore.Mvc;

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
      string output = Content!;

      foreach(var item in SubArticles)
      {
         output += ("\n\r" + "\t" + item.ToString());
      }

      return output;
   }

}
