using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TFG.RulesPenaltiesF1.Core.Entities.CompetitionAggregate;

namespace TFG.RulesPenaltiesF1.Web.ViewModels;

public class CompetitionViewModel
{
   public int Id { get; set; }

	public int Year { get; set; }

   [Required]
   public string Name { get; set; } = string.Empty;

   [Required]
   [DisplayName("Circuit")]
   public int CircuitId { get; set; }

   public CircuitViewModel? Circuit { get; set; }

   [Required]
   [DisplayName("Sprint Race")]
   public bool IsSprint { get; set; }

   [Required]
	[Range(1, 53, ErrorMessage ="A year can't have less than 1 week or more than 53")]
   public int Week { get; set; }

	[DisplayName("State")]
	public CompetitionStateEnum CompetitionState { get; set; } = CompetitionStateEnum.NotStarted;
}
