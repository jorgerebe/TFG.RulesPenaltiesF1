using FluentAssertions;
using TFG.RulesPenaltiesF1.Core.Entities.CompetitionAggregate;
using TFG.RulesPenaltiesF1.Core.Entities.IncidentAggregate;

namespace UnitTests.Core.Entities;

public class CompetitionTests
{
	[Fact]
	public void Constructor_Invalid_NameNull()
	{
		Action action = () => { new Competition(1, null!, false, 1); };

		action.Invoking(a => a()).Should().Throw<ArgumentException>();
	}

	[Fact]
	public void Constructor_Invalid_NameEmpty()
	{
		Action action = () => { new Competition(1, "", false, 1); };

		action.Invoking(a => a()).Should().Throw<ArgumentException>();
	}

	[Fact]
	public void Constructor_Invalid_CircuitNull()
	{
		Action action = () => { new Competition(null!, "name", false, 1); };

		action.Invoking(a => a()).Should().Throw<ArgumentNullException>();
	}

	[Fact]
	public void Constructor_Valid_CircuitObject()
	{
		Circuit circuit = new(1, "circuit", 1, 50, 2020, 1, "driver", 2022);
		circuit.Id = 1;

		Competition competition = new Competition(circuit, "name", false, 1);

		competition.CircuitId.Should().Be(1);
		competition.State.Should().Be(CompetitionStateEnum.NotStarted);
		competition.Name.Should().Be("name");
		competition.IsSprint.Should().Be(false);
		competition.Week.Should().Be(1);

	}

	[Fact]
	public void Constructor_Valid_CircuitId()
	{

		Competition competition = new Competition(1, "name", false, 1);

		competition.CircuitId.Should().Be(1);
		competition.State.Should().Be(CompetitionStateEnum.NotStarted);
		competition.Name.Should().Be("name");
		competition.IsSprint.Should().Be(false);
		competition.Week.Should().Be(1);

	}

	[Fact]
	public void StartCompetitionNotValidAlreadyStarted_Exception()
	{

		Competition competition = new Competition(1, "name", false, 1);

		competition.StartCompetition();

		Action action = () => { competition.StartCompetition(); };

		action.Invoking(a => a()).Should().Throw<InvalidOperationException>();

	}

	[Fact]
	public void StartCompetitionValidNoSprint()
	{

		Competition competition = new Competition(1, "name", false, 1);

		competition.StartCompetition();

		competition.State.Should().Be(CompetitionStateEnum.Started);

		competition.Sessions.Should().HaveCount(3);
		competition.Sessions.ElementAt(0).SessionType.Should().Be(SessionTypeEnum.Practice);
		competition.Sessions.ElementAt(1).SessionType.Should().Be(SessionTypeEnum.Qualifying);
		competition.Sessions.ElementAt(2).SessionType.Should().Be(SessionTypeEnum.Race);

	}

	[Fact]
	public void StartCompetitionValidSprint()
	{

		Competition competition = new Competition(1, "name", true, 1);

		competition.StartCompetition();

		competition.State.Should().Be(CompetitionStateEnum.Started);

		competition.Sessions.Should().HaveCount(5);

		competition.Sessions.ElementAt(0).SessionType.Should().Be(SessionTypeEnum.Practice);
		competition.Sessions.ElementAt(1).SessionType.Should().Be(SessionTypeEnum.Qualifying);
		competition.Sessions.ElementAt(2).SessionType.Should().Be(SessionTypeEnum.SprintShootout);
		competition.Sessions.ElementAt(3).SessionType.Should().Be(SessionTypeEnum.Sprint);
		competition.Sessions.ElementAt(4).SessionType.Should().Be(SessionTypeEnum.Race);
	}


	[Fact]
	public void AddParticipations_Null_Exception()
	{
		Season season = GetSeasonHook();

		Competition competition = season.Competitions.ElementAt(0);

		competition.StartCompetition();


		Action action = () => { competition.AddParticipations(null!); };

		action.Invoking(a => a()).Should().Throw<ArgumentNullException>();
	}

	[Fact]
	public void AddParticipations_Empty_Exception()
	{
		Season season = GetSeasonHook();

		Competition competition = season.Competitions.ElementAt(0);

		competition.StartCompetition();

		Action action = () => { competition.AddParticipations(new List<Participation>()); };

		action.Invoking(a => a()).Should().Throw<ArgumentException>().WithMessage("Can not add 0 participations");
	}

	[Fact]
	public void AddParticipations_CanNotAddParticipation_Exception()
	{
		Season season = GetSeasonHook();

		Competition competition = season.Competitions.ElementAt(0);

		Participation participation = new(competition.Id, season.Competitors.ElementAt(0).Id, 1);

		List<Participation> participations = new() { participation};

		Action action = () => { competition.AddParticipations(participations); };

		action.Invoking(a => a()).Should().Throw<InvalidOperationException>().WithMessage("The competition has not been started or its sessions have started");
	}

	[Fact]
	public void AddParticipations_DriverAlreadyParticipating_Exception()
	{
		Season season = GetSeasonHook();

		Competition competition = season.Competitions.ElementAt(0);

		Participation participation = new(competition.Id, 1, 1);
		Participation participation2 = new(competition.Id, 1, 1);

		List<Participation> participations = new() { participation, participation2};

		competition.StartCompetition();

		Action action = () => { competition.AddParticipations(participations); };

		action.Invoking(a => a()).Should().Throw<ArgumentException>().WithMessage("The same driver can not participate twice in the same competition");
	}

	[Fact]
	public void AddParticipations_DifferentCompetitions_Exception()
	{
		Season season = GetSeasonHook();

		Competition competition = season.Competitions.ElementAt(0);

		Participation participation = new(competition.Id, 1, 1);
		Participation participation2 = new(-1, 1, 2);

		List<Participation> participations = new() { participation, participation2};

		competition.StartCompetition();

		Action action = () => { competition.AddParticipations(participations); };

		action.Invoking(a => a()).Should().Throw<ArgumentException>().WithMessage("A participation from other competitions can not be added to this competition");
	}

	[Fact]
	public void AddParticipations_DifferentCompetitorSameTime_Exception()
	{
		Season season = GetSeasonHook();

		Competition competition = season.Competitions.ElementAt(0);

		Participation participation = new(competition.Id, 1, 1);
		Participation participation2 = new(competition.Id, 2, 2);

		List<Participation> participations = new() { participation, participation2};

		competition.StartCompetition();

		Action action = () => { competition.AddParticipations(participations); };

		action.Invoking(a => a()).Should().Throw<ArgumentException>().WithMessage("A participation with more than one competitor can not be added");
	}

	[Fact]
	public void AddParticipations_CompetitorAlreadyAdded_Exception()
	{
		Season season = GetSeasonHook();

		Competition competition = season.Competitions.ElementAt(0);

		Participation participation = new(competition.Id, 1, 1);
		Participation participation2 = new(competition.Id, 1, 2);
		Participation participation3 = new(competition.Id, 1, 3);

		List<Participation> participations = new() { participation, participation2};
		List<Participation> participations3 = new() { participation3};

		competition.StartCompetition();

		competition.AddParticipations(participations);

		Action action = () => { competition.AddParticipations(participations3); };

		action.Invoking(a => a()).Should().Throw<ArgumentException>().WithMessage("The competitor already have its participations established for this competition");
	}

	[Fact]
	public void AddParticipations_CompetitorNotInSeason_Exception()
	{
		Season season = GetSeasonHook();

		Competition competition = season.Competitions.ElementAt(0);

		Participation participation = new(competition.Id, 4, 1);
		Participation participation2 = new(competition.Id, 4, 2);

		List<Participation> participations = new() { participation, participation2};

		competition.StartCompetition();

		Action action = () => { competition.AddParticipations(participations); };

		action.Invoking(a => a()).Should().Throw<InvalidOperationException>();
	}

	[Fact]
	public void AddParticipations_Valid_Exception()
	{
		Season season = GetSeasonHook();

		Competition competition = season.Competitions.ElementAt(0);

		Participation participation = new(competition.Id, 1, 1);
		Participation participation2 = new(competition.Id, 1, 2);

		List<Participation> participations = new() { participation, participation2};

		competition.StartCompetition();
		competition.AddParticipations(participations);

		competition.Participations.Should().HaveCount(2);
		competition.Participations.ElementAt(0).CompetitorId = 1;
		competition.Participations.ElementAt(0).DriverId = 1;
		competition.Participations.ElementAt(0).CompetitorId = 1;
		competition.Participations.ElementAt(0).DriverId = 2;
	}

	[Fact]
	public void AddParticipations_CompetitionNotInSeason_Exception()
	{
		Season season = GetSeasonHook();

		Competition competition = season.Competitions.ElementAt(0);

		competition.Season = null;

		Participation participation = new(competition.Id, 1, 1);
		Participation participation2 = new(competition.Id, 1, 2);

		List<Participation> participations = new() { participation, participation2};

		competition.StartCompetition();

		Action action = () => { competition.AddParticipations(participations); };

		action.Invoking(a => a()).Should().Throw<InvalidOperationException>();
	}



	[Fact]
	public void Advance_CompetitionNotStarted_Exception()
	{
		Circuit circuit = new(1, "circuit", 1, 50, 2020, 1, "driver", 2022);
		circuit.Id = 1;

		Competition competition = new Competition(circuit, "name", false, 1);

		Action action = () => { competition.Advance(); };

		action.Invoking(a => a()).Should().Throw<InvalidOperationException>().WithMessage("Cannot advance a competition that has not started");
	}


	[Fact]
	public void Advance_CompetitionWithoutAllParticipations_Exception()
	{
		Season season = GetSeasonHook();

		Competition competition = season.Competitions.ElementAt(0);

		competition.StartCompetition();

		Participation participation = new(competition.Id, 1, 1);
		Participation participation2 = new(competition.Id, 1, 2);

		List<Participation> participations = new() { participation, participation2 };
		competition.AddParticipations(participations);

		Action action = () => { competition.Advance(); };

		action.Invoking(a => a()).Should().Throw<InvalidOperationException>().WithMessage("Cannot advance a competition if there are teams without participations");
	}


	[Fact]
	public void Advance_CompetitionWithoutParticipations_Exception()
	{
		Season season = GetSeasonHook();

		Competition competition = season.Competitions.ElementAt(0);

		competition.StartCompetition();

		Action action = () => { competition.Advance(); };

		action.Invoking(a => a()).Should().Throw<InvalidOperationException>().WithMessage("Cannot advance a competition if there are teams without participations");
	}

	[Fact]
	public void Advance_CompetitionFinishedAfterAllSessionsFinished()
	{
		Season season = GetSeasonHook();

		Competition competition = season.Competitions.ElementAt(0);

		competition.StartCompetition();

		Participation participation1 = new(competition.Id, 1, 1);
		Participation participation2 = new(competition.Id, 1, 2);

		List<Participation> participations12 = new() { participation1, participation2 };

		Participation participation3 = new(competition.Id, 2, 3);
		Participation participation4 = new(competition.Id, 2, 4);

		List<Participation> participations34 = new() { participation3, participation4 };

		competition.AddParticipations(participations12);
		competition.AddParticipations(participations34);

		for (int i = 0; i < 3; i++)
		{
			for(int j = 0; j < 2; j++)
			{
				competition.Advance();
			}
		}

		competition.State.Should().Be(CompetitionStateEnum.Finished);
	}

	[Fact]
	public void Advance_CompetitionFinished_Exception()
	{
		Season season = GetSeasonHook();

		Competition competition = season.Competitions.ElementAt(0);

		competition.StartCompetition();

		Participation participation1 = new(competition.Id, 1, 1);
		Participation participation2 = new(competition.Id, 1, 2);

		List<Participation> participations12 = new() { participation1, participation2 };

		Participation participation3 = new(competition.Id, 2, 3);
		Participation participation4 = new(competition.Id, 2, 4);

		List<Participation> participations34 = new() { participation3, participation4 };

		competition.AddParticipations(participations12);
		competition.AddParticipations(participations34);

		for (int i = 0; i < 3; i++)
		{
			for(int j = 0; j < 2; j++)
			{
				competition.Advance();
			}
		}

		Action action = () => { competition.Advance(); };

		action.Invoking(a => a()).Should().Throw<InvalidOperationException>().WithMessage("Cannot advance a competition that has already finished");
	}

	[Fact]
	public void AddIncident_SessionNotStarted_Exception()
	{
		Season season = GetSeasonHook();

		Competition competition = season.Competitions.ElementAt(0);

		competition.StartCompetition();

		Participation participation1 = new(competition.Id, 1, 1);
		Participation participation2 = new(competition.Id, 1, 2);

		List<Participation> participations12 = new() { participation1, participation2 };

		Participation participation3 = new(competition.Id, 2, 3);
		Participation participation4 = new(competition.Id, 2, 4);

		List<Participation> participations34 = new() { participation3, participation4 };

		competition.AddParticipations(participations12);
		competition.AddParticipations(participations34);

		competition.Advance();

		Incident incident = new(new DateTime(2020, 1, 1), 1, -1, "f", 1, null, "r", null, null);

		Action action = () => { competition.AddIncident(incident, competition.Sessions.ElementAt(1)); };

		action.Invoking(a => a()).Should().Throw<InvalidOperationException>().WithMessage("It is not possible to add an incident to the session specified");
	}

	[Fact]
	public void AddIncident_WrongSession_Exception()
	{
		Season season = GetSeasonHook();

		Competition competition = season.Competitions.ElementAt(0);

		competition.StartCompetition();

		Participation participation1 = new(competition.Id, 1, 1);
		Participation participation2 = new(competition.Id, 1, 2);

		List<Participation> participations12 = new() { participation1, participation2 };

		Participation participation3 = new(competition.Id, 2, 3);
		Participation participation4 = new(competition.Id, 2, 4);

		List<Participation> participations34 = new() { participation3, participation4 };

		competition.AddParticipations(participations12);
		competition.AddParticipations(participations34);

		competition.Advance();

		Session session = new(season.Competitions.ElementAt(1), SessionTypeEnum.Sprint);

		Incident incident = new(new DateTime(2020, 1, 1), 1, -1, "f", 1, null, "r", null, null);

		Action action = () => { competition.AddIncident(incident, session); };

		action.Invoking(a => a()).Should().Throw<InvalidOperationException>().WithMessage("It is not possible to add an incident to the session specified");
	}

	[Fact]
	public void AddIncident_WrongSessionAndStarted_Exception()
	{
		Season season = GetSeasonHook();

		Competition competition = season.Competitions.ElementAt(0);

		competition.StartCompetition();

		Participation participation1 = new(competition.Id, 1, 1);
		Participation participation2 = new(competition.Id, 1, 2);

		List<Participation> participations12 = new() { participation1, participation2 };

		Participation participation3 = new(competition.Id, 2, 3);
		Participation participation4 = new(competition.Id, 2, 4);

		List<Participation> participations34 = new() { participation3, participation4 };

		competition.AddParticipations(participations12);
		competition.AddParticipations(participations34);

		competition.Advance();

		Session session = new(season.Competitions.ElementAt(1), SessionTypeEnum.Sprint);
		session.Id = -1;
		session.Advance();

		Incident incident = new(new DateTime(2020, 1, 1), 1, -1, "f", 1, null, "r", null, null);

		Action action = () => { competition.AddIncident(incident, session); };

		action.Invoking(a => a()).Should().Throw<InvalidOperationException>().WithMessage("It is not possible to add an incident to the session specified");
	}

	[Fact]
	public void AddIncident_Valid()
	{
		Season season = GetSeasonHook();

		Competition competition = season.Competitions.ElementAt(0);

		competition.StartCompetition();

		Participation participation1 = new(competition.Id, 1, 1);
		Participation participation2 = new(competition.Id, 1, 2);

		List<Participation> participations12 = new() { participation1, participation2 };

		Participation participation3 = new(competition.Id, 2, 3);
		Participation participation4 = new(competition.Id, 2, 4);

		List<Participation> participations34 = new() { participation3, participation4 };

		competition.AddParticipations(participations12);
		competition.AddParticipations(participations34);

		competition.Advance();

		Session session = competition.Sessions.ElementAt(0);

		Incident incident = new(new DateTime(2020, 1, 1), 1, session.Id, "f", 1, null, "r", null, null);

		competition.AddIncident(incident, session);

		session.Incidents.Should().HaveCount(1);
	}


	private Season GetSeasonHook()
	{
		Circuit circuit = new(1, "circuit", 1, 50, 2020, 1, "driver", 2022);
		circuit.Id = 1;

		Competition competition1 = new Competition(circuit, "name", false, 1);
		Competition competition2 = new Competition(circuit, "name", false, 2);

		competition1.Id = 1;
		competition2.Id = 2;

		List<Competition> competitions = new() { competition1, competition2 };


		Competitor competitor1 = new Competitor(1);
		Competitor competitor2 = new Competitor(2);

		List<Competitor> competitors = new() { competitor1, competitor2 };

		Season season = new Season(2023, competitors, competitions, 1);

		return season;
	}
}
