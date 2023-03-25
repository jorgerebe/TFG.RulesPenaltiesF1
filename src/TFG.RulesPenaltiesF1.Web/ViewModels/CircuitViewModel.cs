using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TFG.RulesPenaltiesF1.Web.ViewModels;

public class CircuitViewModel
{
   public int Id { get; set; }

   [Required]
   [DisplayName("Country")]
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

   [DisplayName("Race Distance")]
   public float RaceDistance { get; set; }

   [Required]
   [Range(1900, 3000)]
   [DisplayName("Year First GP")]
   public int YearFirstGP { get; set; }



   [Required]
   [Range(1, 600000)]
   public int MillisecondsLapRecord { get; set; }

   [Required]
   public string DriverLapRecord { get; set; } = string.Empty;

   [Required]
   [Range(1900, 3000)]
   public int YearLapRecord { get; set; }

   [DisplayName("Lap Record")]
   public string InfoLapRecord { get; set; } = string.Empty;
}
