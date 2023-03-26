using System;
using FluentAssertions;

namespace UnitTests.Core.Entities;
public class CircuitTests
{
   [Fact]
   public void Constructor_1CharNameMinimumLength1LapCurrentYearMinimumMilliseconds1CharDriverNameYearLapRecordEqualsFirstGPYear()
   {
      var circuit = new Circuit(new Country("A"), "1", 0.001f, 1, DateTime.Now.Year, 1, "1", DateTime.Now.Year);

      circuit.Country!.Name.Should().Be("A");
      circuit.Name.Should().Be("1");
      circuit.Length.Should().Be(0.001f);
      circuit.Laps.Should().Be(1);
      circuit.YearFirstGP.Should().Be(DateTime.Now.Year);
      circuit.MillisecondsLapRecord.Should().Be(1);
      circuit.DriverLapRecord.Should().Be("1");
      circuit.YearLapRecord.Should().Be(DateTime.Now.Year);
   }

   [Fact]
   public void Constructor_CountryNull_ThrowsException()
   {
      Action action = () => { new Circuit(null!, "1", 0.001f, 1, DateTime.Now.Year, 1, "1", DateTime.Now.Year); };
      action.Invoking(a => a()).Should().Throw<ArgumentException>();
   }

   [Fact]
   public void Constructor_NameEmpty_ThrowsException()
   {
      Action action = () => { new Circuit(new Country("A"), "", 0.001f, 1, DateTime.Now.Year, 1, "1", DateTime.Now.Year); };
      action.Invoking(a => a()).Should().Throw<ArgumentException>();
   }

   [Fact]
   public void Constructor_NameNull_ThrowsException()
   {
      Action action = () => { new Circuit(new Country("A"), null!, 0.001f, 1, DateTime.Now.Year, 1, "1", DateTime.Now.Year); };
      action.Invoking(a => a()).Should().Throw<ArgumentException>();
   }

   [Fact]
   public void Constructor_LengthZero_ThrowsException()
   {
      Action action = () => { new Circuit(new Country("A"), "1", 0, 1, DateTime.Now.Year, 1, "1", DateTime.Now.Year); };
      action.Invoking(a => a()).Should().Throw<ArgumentException>().WithMessage("Length must be greater than 0");
   }

   [Fact]
   public void Constructor_YearGreaterThanCurrent_ThrowsException()
   {
      Action action = () => { new Circuit(new Country("A"), "1", 0.001f, 1, DateTime.Now.Year+1, 1, "1", DateTime.Now.Year); };
      action.Invoking(a => a()).Should().Throw<ArgumentException>().WithMessage("YearFirstGP must be less than current year");
   }

   [Fact]
   public void Constructor_LapsZero_ThrowsException()
   {
      Action action = () => { new Circuit(new Country("A"), "1", 0.001f, 0, DateTime.Now.Year, 0, "1", DateTime.Now.Year); };
      action.Invoking(a => a()).Should().Throw<ArgumentException>().WithMessage("Laps must be greater than 0");
   }

   [Fact]
   public void Constructor_NameDriverEmpty_ThrowsException()
   {
      Action action = () => { new Circuit(new Country("A"), "1", 0.001f, 1, DateTime.Now.Year, 1, "", DateTime.Now.Year); };
      action.Invoking(a => a()).Should().Throw<ArgumentException>();
   }

   [Fact]
   public void Constructor_NameDriverNull_ThrowsException()
   {
      Action action = () => { new Circuit(new Country("A"), "1", 0.001f, 1, DateTime.Now.Year, 1, null!, DateTime.Now.Year); };
      action.Invoking(a => a()).Should().Throw<ArgumentException>();
   }

   [Fact]
   public void Constructor_YearRecordLapLessThanFirstYear_ThrowsException()
   {
      Action action = () => { new Circuit(new Country("A"), "1", 0.001f, 1, DateTime.Now.Year, 1, "1", DateTime.Now.Year-1); };
      action.Invoking(a => a()).Should().Throw<ArgumentException>().WithMessage("YearLapRecord must be greater than YearFirstGP and less than the current year");
   }

   [Fact]
   public void Constructor_YearRecordLapGreaterThanCurrentYear_ThrowsException()
   {
      Action action = () => { new Circuit(new Country("A"), "1", 0.001f, 1, DateTime.Now.Year, 1, "1", DateTime.Now.Year+1); };
      action.Invoking(a => a()).Should().Throw<ArgumentException>().WithMessage("YearLapRecord must be greater than YearFirstGP and less than the current year");
   }

   [Fact]
   public void FormatFastLap0Minutes0Seconds0Milliseconds()
   {
      Circuit circuit = new Circuit(-1, "test", 5, 5, 2001, 0, "test driver", 2020);

      circuit.FormatFastLap().Should().Be("0:00.000");
   }
   
   [Fact]
   public void FormatFastLap1Minute11Seconds111Milliseconds()
   {
      Circuit circuit = new Circuit(-1, "test", 5, 5, 2001, 71111, "test driver", 2020);

      circuit.FormatFastLap().Should().Be("1:11.111");
   }
}
