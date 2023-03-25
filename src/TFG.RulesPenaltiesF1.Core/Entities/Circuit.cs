using TFG.RulesPenaltiesF1.Core.Interfaces;

namespace TFG.RulesPenaltiesF1.Core.Entities;
public class Circuit : EntityBase, IAggregateRoot
{
   public Country? Country { get; set; } = null;
   public int CountryId { get; set; }

   public string Name { get; set; }

   public float Length { get; set; }

   public float Laps { get; set; }
   public int YearFirstGP { get; set; }
   public int MillisecondsLapRecord { get; set; }
   public string DriverLapRecord { get; set; }
   public int YearLapRecord { get; set; }


   public Circuit(Country country, string name, float length, float laps, int yearFirstGP, int millisecondsLapRecord, string driverLapRecord, int yearLapRecord)
   {
      Country = country;
      Name = name;
      Length = length;
      Laps = laps;
      YearFirstGP = yearFirstGP;
      MillisecondsLapRecord = millisecondsLapRecord;
      DriverLapRecord = driverLapRecord;
      YearLapRecord = yearLapRecord;
   }
   
   public Circuit(int countryId, string name, float length, float laps, int yearFirstGP, int millisecondsLapRecord, string driverLapRecord, int yearLapRecord)
   {
      CountryId = countryId;
      Name = name;
      Length = length;
      Laps = laps;
      YearFirstGP = yearFirstGP;
      MillisecondsLapRecord = millisecondsLapRecord;
      DriverLapRecord = driverLapRecord;
      YearLapRecord = yearLapRecord;
   }

   public string FormatFastLap()
   {
      int minutes = MillisecondsLapRecord / 60000;
      int seconds = (MillisecondsLapRecord - (60000 * minutes))/1000;
      int milliseconds = (MillisecondsLapRecord - (60000 * minutes) - (1000 * seconds));

      return minutes + ":" + seconds.ToString("00") + "." + milliseconds.ToString("000");
   }
}
