using System.ComponentModel.DataAnnotations;
using TFG.RulesPenaltiesF1.Core.Entities.RegulationAggregate;
using TFG.RulesPenaltiesF1.Web.ViewModels.Penalties;

namespace TFG.RulesPenaltiesF1.Web.ViewModels;

public class RegulationViewModel
{
   public int Id { get; set; }

   public string Name { get; set; } = string.Empty;

   [Required]
   [MinLength(1, ErrorMessage ="There must be at least one article in the regulations")]
   public List<int> Articles { get; set; } = new();
   
   [Required]
   [MinLength(1, ErrorMessage ="There must be at least one penalty in the regulations")]
   public List<int> Penalties { get; set; } = new();

   public List<ArticleViewModel> ArticlesContent { get; set; } = new();
   public List<PenaltyViewModel> PenaltiesContent { get; set; } = new();

	public static Regulation? MapViewModelToEntity(RegulationViewModel regulation)
	{
		if (regulation is null)
		{
			return null;
		}

		List<RegulationArticle> regulationArticles = new();

		foreach (int id in regulation.Articles)
		{
			regulationArticles.Add(new RegulationArticle(0, id));
		}

		List<RegulationPenalty> regulationPenalties = new();

		foreach (int id in regulation.Penalties)
		{
			regulationPenalties.Add(new RegulationPenalty(0, id));
		}

		var regulationEntity = new Regulation(regulation.Name, regulationArticles, regulationPenalties);

		return regulationEntity;
	}

	public static RegulationViewModel? MapEntityToViewModel(Regulation regulation)
	{
		if(regulation is null)
		{
			return null;
		}

		List<ArticleViewModel> articles = new();

		foreach (var article in regulation.Articles)
		{
			articles.Add(ArticleViewModel.MapEntityToViewModel(article.Article!)!);
		}

		List<PenaltyViewModel> penalties = new();

		foreach (var penalty in regulation.Penalties)
		{
			penalties.Add(PenaltyViewModelFactory.CreateViewModel(penalty.Penalty!));
		}

		return new RegulationViewModel()
		{
			Id = regulation.Id,
			Name = regulation.Name,
			ArticlesContent = articles,
			PenaltiesContent = penalties
		};
	}
}
