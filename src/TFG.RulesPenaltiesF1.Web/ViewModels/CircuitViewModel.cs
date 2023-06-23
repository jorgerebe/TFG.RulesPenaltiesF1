using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TFG.RulesPenaltiesF1.Core.Entities;

namespace TFG.RulesPenaltiesF1.Web.ViewModels;

public class CircuitViewModel
{
   public int Id { get; set; }

   [Required]
   [DisplayName("Country")]
   public int CountryId { get; set; }

   public CountryViewModel Country { get; set; } = new();

   [Required]
	[MinLength(5, ErrorMessage = "Name can not be empty")]
	public string Name { get; set; } = string.Empty;

   [Required]
   [Range(0, 100)]
   public float Length { get; set; }

   [Required]
   [Range(1, 200)]
   public int Laps { get; set; }

   [DisplayName("Race Distance")]
   public float RaceDistance { get; set; }

	[Required]
	[DisplayName("Year of first GP")]
	public int YearFirstGP { get; set; }

   [Required]
   [Range(0, 20)]
   [DisplayName("Minutes")]
   public int MinutesLapRecord { get; set; }

   [Required]
   [Range(0,59.999)]
   [DisplayName("Seconds")]
   public float SecondsLapRecord { get; set; }


   public int MillisecondsLapRecord { get; set; }

   [Required]
	[MinLength(5, ErrorMessage ="Driver name can not be empty")]
   public string DriverLapRecord { get; set; } = string.Empty;

   [Required]
	[DisplayName("Year Lap Record")]
	public int YearLapRecord { get; set; }

   [DisplayName("Lap Record")]
   public string InfoLapRecord { get; set; } = string.Empty;

	public static CircuitViewModel? MapEntityToViewModel(Circuit circuit)
	{
		if (circuit == null)
		{
			return null;
		}


		return new CircuitViewModel()
		{
			Id = circuit.Id,
			Country = new CountryViewModel() { Id = circuit.Country!.Id, Name = circuit.Country.Name },
			Name = circuit.Name,
			Length = circuit.Length,
			Laps = circuit.Laps,
			RaceDistance = circuit.Length * circuit.Laps,
			YearFirstGP = circuit.YearFirstGP,
			MillisecondsLapRecord = circuit.MillisecondsLapRecord,
			DriverLapRecord = circuit.DriverLapRecord,
			YearLapRecord = circuit.YearLapRecord,
			InfoLapRecord = circuit.FormatFastLap() + " - " + circuit.DriverLapRecord + " (" + circuit.YearLapRecord + ")"
		};
	}

	public static Circuit? MapViewModelToEntity(CircuitViewModel circuit)
	{
		if (circuit is null)
		{
			return null;
		}

		var milliseconds = circuit.MinutesLapRecord * 60000 + (int)(circuit.SecondsLapRecord * 1000);

		Circuit circuitEntity = new Circuit(circuit.CountryId, circuit.Name, circuit.Length,
			 circuit.Laps, circuit.YearFirstGP, milliseconds, circuit.DriverLapRecord, circuit.YearLapRecord);

		return circuitEntity;
	}
}
