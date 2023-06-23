using System;
using FluentAssertions;

namespace UnitTests.Core.Entities;
public class CircuitTests
{
   [Fact]
   public void Constructor_1CharNameMinimumLength1LapCurrentYearMinimumMilliseconds1CharDriverNameYearLapRecordEqualsFirstGPYear()
   {
      var circuit = new Circuit(new Country("A"), "1", 0.001f, 1, 2000, 1, "1", 2000);

      circuit.Country!.Name.Should().Be("A");
      circuit.Name.Should().Be("1");
      circuit.Length.Should().Be(0.001f);
      circuit.Laps.Should().Be(1);
      circuit.YearFirstGP.Should().Be(2000);
      circuit.MillisecondsLapRecord.Should().Be(1);
      circuit.DriverLapRecord.Should().Be("1");
      circuit.YearLapRecord.Should().Be(2000);
   }

   [Fact]
   public void Constructor_CountryNull_ThrowsException()
   {
      Action action = () => { new Circuit(null!, "1", 0.001f, 1, 2000, 1, "1", 2000); };
      action.Invoking(a => a()).Should().Throw<ArgumentException>();
   }

   [Fact]
   public void Constructor_NameEmpty_ThrowsException()
   {
      Action action = () => { new Circuit(new Country("A"), "", 0.001f, 1, 2000, 1, "1", 2000); };
      action.Invoking(a => a()).Should().Throw<ArgumentException>();
   }

   [Fact]
   public void Constructor_NameNull_ThrowsException()
   {
      Action action = () => { new Circuit(new Country("A"), null!, 0.001f, 1, 2000, 1, "1", 2000); };
      action.Invoking(a => a()).Should().Throw<ArgumentException>();
   }

   [Fact]
   public void Constructor_LengthZero_ThrowsException()
   {
      Action action = () => { new Circuit(new Country("A"), "1", 0, 1, 2000, 1, "1", 2000); };
      action.Invoking(a => a()).Should().Throw<ArgumentException>().WithMessage("Length must be greater than 0");
   }

   [Fact]
   public void Constructor_LapsZero_ThrowsException()
   {
      Action action = () => { new Circuit(new Country("A"), "1", 0.001f, 0, 2000, 0, "1", 2000); };
      action.Invoking(a => a()).Should().Throw<ArgumentException>().WithMessage("Laps must be greater than 0");
   }

   [Fact]
   public void Constructor_NameDriverEmpty_ThrowsException()
   {
      Action action = () => { new Circuit(new Country("A"), "1", 0.001f, 1, 2000, 1, "", 2000); };
      action.Invoking(a => a()).Should().Throw<ArgumentException>();
   }

   [Fact]
   public void Constructor_NameDriverNull_ThrowsException()
   {
      Action action = () => { new Circuit(new Country("A"), "1", 0.001f, 1, 2000, 1, null!, 2000); };
      action.Invoking(a => a()).Should().Throw<ArgumentException>();
   }

   [Fact]
   public void Constructor_YearRecordLapLessThanFirstYear_ThrowsException()
   {
      Action action = () => { new Circuit(new Country("A"), "1", 0.001f, 1, 2000, 1, "1", 2000-1); };
      action.Invoking(a => a()).Should().Throw<ArgumentException>().WithMessage("YearLapRecord must be greater than YearFirstGP and less than the current year");
   }

	[Fact]
	public void Constructor_Milliseconds_Zero_ThrowsException()
	{
		Action action = () => { new Circuit(new Country("A"), "1", 0.001f, 1, 2000, -1, "1", 2000 - 1); };
		action.Invoking(a => a()).Should().Throw<ArgumentException>().WithMessage("MillisecondsLapRecord must be greater than 0");
	}

	[Fact]
   public void FormatFastLap0Minutes0Seconds0Milliseconds()
   {
      Circuit circuit = new Circuit(-1, "test", 5, 5, 2001, 1, "test driver", 2020);

      circuit.FormatFastLap().Should().Be("0:00.001");
   }
   
   [Fact]
   public void FormatFastLap1Minute11Seconds111Milliseconds()
   {
      Circuit circuit = new Circuit(-1, "test", 5, 5, 2001, 71111, "test driver", 2020);

      circuit.FormatFastLap().Should().Be("1:11.111");
   }
}
