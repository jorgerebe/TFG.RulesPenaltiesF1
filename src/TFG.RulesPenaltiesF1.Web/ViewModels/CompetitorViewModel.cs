using System.ComponentModel;
using Microsoft.Build.Framework;

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
   public string PowerUnit { get; set; } = string.Empty;
}
