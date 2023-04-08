using System.ComponentModel.DataAnnotations;

namespace TFG.RulesPenaltiesF1.Web.ViewModels;

public class CompetitionViewModel
{
   public int Id { get; set; }

   [Required]
   public string Name { get; set; } = string.Empty;

   [Required]
   public int CircuitId { get; set; }

   public CircuitViewModel Circuit { get; set; } = new();

   [Required]
   public bool IsSprint { get; set; }

   [Required]
   public int Week { get; set; }
}
