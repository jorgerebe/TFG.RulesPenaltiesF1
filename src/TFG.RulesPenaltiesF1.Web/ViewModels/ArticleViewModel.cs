using System.ComponentModel.DataAnnotations;
using TFG.RulesPenaltiesF1.Core.Entities;

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
      else
      {
         output += ": ";
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

	public static ArticleViewModel? MapEntityToViewModel(Article article)
	{
		if (article == null)
		{
			return null;
		}

		ArticleViewModel viewmodel = new ArticleViewModel(article.Content)
		{
			Id = article.Id
		};

		foreach (var subarticle in article.SubArticles)
		{
			if (subarticle.Content != null)
			{
				ArticleViewModel subarticleViewModel = new ArticleViewModel(subarticle.Content);
				viewmodel.SubArticles.Add(subarticleViewModel);
			}
		}

		return viewmodel;
	}


	public static Article? MapViewModelToEntity(ArticleViewModel article)
	{
		if (article.Content == null)
		{
			return null;
		}

		Article result = new Article(article.Content!);

		foreach (var subarticle in article.SubArticles)
		{
			if (subarticle.Content != null)
			{
				result.AddSubArticle(new Article(subarticle.Content));
			}
		}

		return result;
	}

}
