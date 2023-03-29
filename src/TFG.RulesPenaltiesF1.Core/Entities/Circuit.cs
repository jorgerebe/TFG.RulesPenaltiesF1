using TFG.RulesPenaltiesF1.Core.Interfaces;

namespace TFG.RulesPenaltiesF1.Core.Entities;
public class Circuit : EntityBase, IAggregateRoot
{
   public Country? Country { get; set; } = null;
   public int CountryId { get; set; }

   public string Name { get; set; }

   public float Length { get; set; }

   public int Laps { get; set; }
   public int YearFirstGP { get; set; }
   public int MillisecondsLapRecord { get; set; }
   public string DriverLapRecord { get; set; }
   public int YearLapRecord { get; set; }


   public Circuit(Country country, string name, float length, int laps, int yearFirstGP, int millisecondsLapRecord, string driverLapRecord, int yearLapRecord)
   {
      ArgumentNullException.ThrowIfNull(country, nameof(country));
      CheckArguments(name, length, laps, yearFirstGP, millisecondsLapRecord, driverLapRecord, yearLapRecord);

      Country = country;
      Name = name;
      Length = length;
      Laps = laps;
      YearFirstGP = yearFirstGP;
      MillisecondsLapRecord = millisecondsLapRecord;
      DriverLapRecord = driverLapRecord;
      YearLapRecord = yearLapRecord;
   }
   
   public Circuit(int countryId, string name, float length, int laps, int yearFirstGP, int millisecondsLapRecord, string driverLapRecord, int yearLapRecord)
   {
      CountryId = countryId;

      CheckArguments(name, length, laps, yearFirstGP, millisecondsLapRecord, driverLapRecord, yearLapRecord);

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

   private void CheckArguments(string name, float length, int laps, int yearFirstGP, int millisecondsLapRecord, string driverLapRecord, int yearLapRecord)
   {
      ArgumentException.ThrowIfNullOrEmpty(name, nameof(name));

      if (length <= 0)
      {
         throw new ArgumentException("Length must be greater than 0");
      }

      if (laps <= 0)
      {
         throw new ArgumentException("Laps must be greater than 0");
      }

      if (yearFirstGP > DateTime.Now.Year)
      {
         throw new ArgumentException("YearFirstGP must be less than current year");
      }

      if (millisecondsLapRecord < 0)
      {
         throw new ArgumentException("MillisecondsLapRecord must be greater than 0");
      }

      ArgumentException.ThrowIfNullOrEmpty(driverLapRecord, nameof(driverLapRecord));

      if (yearLapRecord < yearFirstGP || yearLapRecord > DateTime.Now.Year)
      {
         throw new ArgumentException("YearLapRecord must be greater than YearFirstGP and less than the current year");
      }
   }
}
