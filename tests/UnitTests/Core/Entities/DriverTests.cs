using FluentAssertions;
using Moq;
using TFG.RulesPenaltiesF1.Core.Interfaces;

namespace UnitTests.Core.Entities;

public class DriverTests
{
	[Fact]
	public void Constructor_NameNull_ThrowsException()
	{
		var mockDateTimeService = new Mock<IDateTimeService>();

		Action action = () => { new Driver(null!, DateOnly.FromDateTime(new DateTime(2000, 2, 2)), null, mockDateTimeService.Object); };

		action.Invoking(a => a()).Should().Throw<ArgumentException>();
	}

	[Fact]
	public void Constructor_NameEmpty_ThrowsException()
	{
		var mockDateTimeService = new Mock<IDateTimeService>();

		Action action = () => { new Driver("", DateOnly.FromDateTime(new DateTime(2000, 2, 2)), null, mockDateTimeService.Object); };

		action.Invoking(a => a()).Should().Throw<ArgumentException>();
	}

	[Fact]
	public void Constructor_UnderAge_ThrowsException()
	{
		var mockDateTimeService = new Mock<IDateTimeService>();

		mockDateTimeService.Setup(dateTime => dateTime.Now()).Returns(new DateTime(2018, 2, 1));

		Action action = () => { new Driver("Driver Name", DateOnly.FromDateTime(new DateTime(2000, 2, 2)), new Competitor(1), mockDateTimeService.Object); };

		action.Invoking(a => a()).Should().Throw<ArgumentException>().WithMessage("A driver must be over 18");
	}

	[Fact]
	public void Constructor_Valid_CompetorEntity()
	{
		var mockDateTimeService = new Mock<IDateTimeService>();

		mockDateTimeService.Setup(dateTime => dateTime.Now()).Returns(new DateTime(2018, 2, 2));

		Driver driver = new Driver("Driver Name", DateOnly.FromDateTime(new DateTime(2000, 2, 2)), new Competitor(1), mockDateTimeService.Object);

		driver.Name.Should().Be("Driver Name");
		driver.DateBirth.Should().Be(DateOnly.FromDateTime(new DateTime(2000, 2, 2)));
		driver.LicensePoints.Should().Be(0);
		driver.CompetitorId.Should().Be(1);
	}

	[Fact]
	public void Constructor_Valid_CompetorId()
	{
		var mockDateTimeService = new Mock<IDateTimeService>();

		mockDateTimeService.Setup(dateTime => dateTime.Now()).Returns(new DateTime(2018, 2, 2));

		Driver driver = new Driver("Driver Name", DateOnly.FromDateTime(new DateTime(2000, 2, 2)), 1, mockDateTimeService.Object);

		driver.Name.Should().Be("Driver Name");
		driver.DateBirth.Should().Be(DateOnly.FromDateTime(new DateTime(2000, 2, 2)));
		driver.LicensePoints.Should().Be(0);
		driver.CompetitorId.Should().Be(1);
	}

	[Fact]
	public void RemoveTeamTest()
	{
		var mockDateTimeService = new Mock<IDateTimeService>();

		mockDateTimeService.Setup(dateTime => dateTime.Now()).Returns(new DateTime(2018, 2, 2));

		Driver driver = new Driver("Driver Name", DateOnly.FromDateTime(new DateTime(2000, 2, 2)), new Competitor(1), mockDateTimeService.Object);

		driver.AddTeam(null);

		driver.Competitor.Should().Be(null);
		driver.CompetitorId.Should().Be(null);
	}

	[Fact]
	public void ChangeTeamTest()
	{
		var mockDateTimeService = new Mock<IDateTimeService>();

		mockDateTimeService.Setup(dateTime => dateTime.Now()).Returns(new DateTime(2018, 2, 2));

		Driver driver = new Driver("Driver Name", DateOnly.FromDateTime(new DateTime(2000, 2, 2)), new Competitor(1), mockDateTimeService.Object);

		driver.AddTeam(new Competitor(3));

		driver.Competitor.Should().NotBe(null);
		driver.CompetitorId.Should().Be(3);
	}

	[Fact]
	public void AddLicensePoints()
	{
		var mockDateTimeService = new Mock<IDateTimeService>();

		mockDateTimeService.Setup(dateTime => dateTime.Now()).Returns(new DateTime(2018, 2, 2));

		Driver driver = new Driver("Driver Name", DateOnly.FromDateTime(new DateTime(2000, 2, 2)), new Competitor(1), mockDateTimeService.Object);

		driver.AddLicensePoints(3);

		driver.LicensePoints.Should().Be(3);
	}

	[Fact]
	public void AddLicensePointsTooMany()
	{
		var mockDateTimeService = new Mock<IDateTimeService>();

		mockDateTimeService.Setup(dateTime => dateTime.Now()).Returns(new DateTime(2018, 2, 2));

		Driver driver = new Driver("Driver Name", DateOnly.FromDateTime(new DateTime(2000, 2, 2)), new Competitor(1), mockDateTimeService.Object);

		Action action = () => { driver.AddLicensePoints(13); };

		action.Invoking(a => a()).Should().Throw<ArgumentException>();
	}

	[Fact]
	public void CanAddOneLicensePointsTrue()
	{
		var mockDateTimeService = new Mock<IDateTimeService>();

		mockDateTimeService.Setup(dateTime => dateTime.Now()).Returns(new DateTime(2018, 2, 2));

		Driver driver = new Driver("Driver Name", DateOnly.FromDateTime(new DateTime(2000, 2, 2)), new Competitor(1), mockDateTimeService.Object);

		driver.CanAddLicensePoints(1).Should().Be(true);
	}

	[Fact]
	public void CanAddLicensePointsThirteenFalse()
	{
		var mockDateTimeService = new Mock<IDateTimeService>();

		mockDateTimeService.Setup(dateTime => dateTime.Now()).Returns(new DateTime(2018, 2, 2));

		Driver driver = new Driver("Driver Name", DateOnly.FromDateTime(new DateTime(2000, 2, 2)), new Competitor(1), mockDateTimeService.Object);

		driver.CanAddLicensePoints(13).Should().Be(false);
	}
}
