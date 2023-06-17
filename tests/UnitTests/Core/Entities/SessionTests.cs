using FluentAssertions;
using TFG.RulesPenaltiesF1.Core.Entities.CompetitionAggregate;
using TFG.RulesPenaltiesF1.Core.Entities.IncidentAggregate;

namespace UnitTests.Core.Entities;

public class SessionTests
{
	[Fact]
	public void Constructor_Valid()
	{
		Competition competition = new(1, "bahrain grand prix", false, 1);
		competition.Id = 2;

		Session session = new Session(competition, SessionTypeEnum.Practice);

		session.CompetitionId.Should().Be(2);
		session.SessionType.Should().Be(SessionTypeEnum.Practice);
		session.State.Should().Be(SessionStateEnum.NotStarted);
	}

	[Fact]
	public void Constructor_CompetitionNull_ThrowsException()
	{
		Action action = () => { new Session(null!, SessionTypeEnum.Practice); };

		action.Invoking(a => a()).Should().Throw<ArgumentException>();
	}

	[Fact]
	public void Constructor_TypeNull_ThrowsException()
	{
		Competition competition = new(1, "bahrain grand prix", false, 1);

		Action action = () => { new Session(competition, null!); };

		action.Invoking(a => a()).Should().Throw<ArgumentException>();
	}


	[Fact]
	public void Advance_FromNotStartedToStarted()
	{
		Competition competition = new(1, "bahrain grand prix", false, 1);
		competition.Id = 2;

		Session session = new Session(competition, SessionTypeEnum.Practice);

		session.State.Should().Be(SessionStateEnum.NotStarted);
		session.Advance();
		session.State.Should().Be(SessionStateEnum.Started);
	}


	[Fact]
	public void Advance_FromStartedToFinished()
	{
		Competition competition = new(1, "bahrain grand prix", false, 1);
		competition.Id = 2;

		Session session = new Session(competition, SessionTypeEnum.Practice);

		session.Advance();
		session.State.Should().Be(SessionStateEnum.Started);
		
		session.Advance();
		session.State.Should().Be(SessionStateEnum.Finished);
	}

	[Fact]
	public void Advance_FromFinished_Exception()
	{
		Competition competition = new(1, "bahrain grand prix", false, 1);
		competition.Id = 2;

		Session session = new Session(competition, SessionTypeEnum.Practice);

		session.Advance();
		session.Advance();

		Action action = () => { session.Advance(); };
		action.Invoking(a => a()).Should().Throw<InvalidOperationException>().WithMessage("The session is already finished");
	}

	[Fact]
	public void IsFinishedShouldBeFalse()
	{
		Competition competition = new(1, "bahrain grand prix", false, 1);
		competition.Id = 2;

		Session session = new Session(competition, SessionTypeEnum.Practice);

		session.HasFinished().Should().Be(false);
	}

	[Fact]
	public void IsFinishedShouldBeTrue()
	{
		Competition competition = new(1, "bahrain grand prix", false, 1);
		competition.Id = 2;

		Session session = new Session(competition, SessionTypeEnum.Practice);

		session.Advance();
		session.Advance();

		session.HasFinished().Should().Be(true);
	}

	[Fact]
	public void CanAddIncidentShouldBeFalse()
	{
		Competition competition = new(1, "bahrain grand prix", false, 1);
		competition.Id = 2;

		Session session = new Session(competition, SessionTypeEnum.Practice);

		session.CanAddIncident().Should().Be(false);
	}

	[Fact]
	public void CanAddIncidentShouldBeTrue()
	{
		Competition competition = new(1, "bahrain grand prix", false, 1);
		competition.Id = 2;

		Session session = new Session(competition, SessionTypeEnum.Practice);

		session.Advance();

		session.CanAddIncident().Should().Be(true);
	}

	[Fact]
	public void AddIncident_InvalidIncidentNull_Exception()
	{
		Competition competition = new(1, "bahrain grand prix", false, 1);
		competition.Id = 2;

		Session session = new Session(competition, SessionTypeEnum.Practice);

		session.Advance();

		Action action = () => { session.AddIncident(null!); };
		action.Invoking(a => a()).Should().Throw<ArgumentException>();
	}


	[Fact]
	public void AddIncident_InvalidState_Exception()
	{
		Competition competition = new(1, "bahrain grand prix", false, 1);
		competition.Id = 2;

		Session session = new Session(competition, SessionTypeEnum.Practice);
		Incident incident = new Incident(new DateTime(2023, 6, 16), 1, 1, "f", 1, null, "r", null, null);

		session.Advance();
		session.Advance();

		Action action = () => { session.AddIncident(incident); };
		action.Invoking(a => a()).Should().Throw<InvalidOperationException>();
	}


	[Fact]
	public void AddIncident_Valid()
	{
		Competition competition = new(1, "bahrain grand prix", false, 1);
		competition.Id = 2;

		Session session = new Session(competition, SessionTypeEnum.Practice);

		Incident incident = new Incident(new DateTime(2023, 6, 16), 1, 1, "f", 1, null, "r", null, null);

		session.Advance();

		session.Incidents.Should().HaveCount(0);
		session.AddIncident(incident);
		session.Incidents.Should().HaveCount(1);
	}
}
