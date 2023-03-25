using System.ComponentModel.DataAnnotations;
using TFG.RulesPenaltiesF1.Core.Entities;

namespace TFG.RulesPenaltiesF1.Web.ViewModels;

public class CircuitViewModel
{
   public int Id { get; set; }

   [Required]
   public int CountryId { get; set; }

   public CountryViewModel Country { get; set; } = new();

   [Required]
   public string Name { get; set; } = string.Empty;
   [Required]
   [Range(0, 100)]
   public float Length { get; set; }
   [Required]
   [Range(1, 1000)]
   public float Laps { get; set; }
   [Required]
   [Range(1900, 3000)]

   public float RaceDistance { get; set; }

   public int YearFirstGP { get; set; }
   [Required]
   [Range(1, 600000)]
   public int MillisecondsLapRecord { get; set; }
   [Required]
   [Range(0,100)]
	public int DriverLapRecord { get; set; }
   [Required]
   [Range(1900, 3000)]
   public int YearLapRecord { get; set; }
}
