using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TFG.RulesPenaltiesF1.Core.Entities;

namespace TFG.RulesPenaltiesF1.Web.ViewModels;

public class CompetitorViewModel
{
   public int Id { get; set; }

   [Required]
   public string Name { get; set; } = string.Empty;

   [Required]
   public string Location { get; set; } = string.Empty;

   [Required]
   [DisplayName("Team Principal")]
   public string TeamPrincipalId { get; set; } = string.Empty;

   [DisplayName("Team Principal")]
   public string TeamPrincipalName { get; set; } = string.Empty;

   [Required]
	[DisplayName("Power Unit")]
	public string PowerUnit { get; set; } = string.Empty;

	public static CompetitorViewModel MapEntityToViewModel(Competitor competitor)
	{
		ArgumentNullException.ThrowIfNull(competitor);

		CompetitorViewModel competitorViewModel = new()
		{
			Id = competitor.Id,
			Name = competitor.Name,
			Location = competitor.Location,
			TeamPrincipalName = (competitor.TeamPrincipal != null) ? competitor.TeamPrincipal.FullName : "",
			PowerUnit = competitor.PowerUnit
		};

		return competitorViewModel;
	}

	public static Competitor? MapViewModelToEntity(CompetitorViewModel competitor)
	{
		ArgumentNullException.ThrowIfNull(competitor);

		Competitor competitorEntity = new Competitor(competitor.Name, competitor.Location, competitor.TeamPrincipalId!, competitor.PowerUnit);

		return competitorEntity;
	}
}
