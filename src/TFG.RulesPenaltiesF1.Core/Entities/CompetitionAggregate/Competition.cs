using TFG.RulesPenaltiesF1.Core.Entities.CompetitionAggregate.Events;
using TFG.RulesPenaltiesF1.Core.Entities.IncidentAggregate;
using TFG.RulesPenaltiesF1.Core.Entities.IncidentAggregate.Events;
using TFG.RulesPenaltiesF1.Core.Interfaces;

namespace TFG.RulesPenaltiesF1.Core.Entities.CompetitionAggregate;

/// <summary>
/// Class <c>Competition</c> models a competition of a season
/// </summary>

public class Competition : EntityBase, IAggregateRoot
{
	public Season? Season { get; set; }
	public int SeasonId { get; set; }

	public Circuit? Circuit { get; private set; }
	public int CircuitId { get; private set; }

	public CompetitionStateEnum State { get; private set; }

	public string Name { get; private set; } = string.Empty;
	public bool IsSprint { get; private set; }
	public int Week { get; private set; }

	private List<Session> _sessions = new();
	public IReadOnlyCollection<Session> Sessions => _sessions.AsReadOnly();

	private List<Participation> _participations = new();
	public IReadOnlyCollection<Participation> Participations => _participations.AsReadOnly();

	public Competition(Circuit circuit, string name, bool isSprint, int week)
	{
		CheckArguments(name);

		ArgumentNullException.ThrowIfNull(circuit);

		Circuit = circuit;
		CircuitId = circuit.Id;

		Name = name;
		IsSprint = isSprint;
		Week = week;
		State = CompetitionStateEnum.NotStarted;
	}

	public Competition(int circuitId, string name, bool isSprint, int week)
	{
		CheckArguments(name);

		CircuitId = circuitId;

		Name = name;
		IsSprint = isSprint;
		Week = week;
		State = CompetitionStateEnum.NotStarted;
	}

	public void StartCompetition()
	{
		if (!State.Equals(CompetitionStateEnum.NotStarted))
		{
			throw new InvalidOperationException();
		}

		State = CompetitionStateEnum.Started;

		_sessions.Add(new (this, SessionTypeEnum.Practice));
		_sessions.Add(new (this, SessionTypeEnum.Qualifying));

		if (IsSprint)
		{
			_sessions.Add(new Session(this, SessionTypeEnum.SprintShootout));
			_sessions.Add(new Session(this, SessionTypeEnum.Sprint));
		}

		_sessions.Add(new Session(this, SessionTypeEnum.Race));

		base.RegisterDomainEvent(new CompetitionStartedEvent(this));
	}

	public void AddParticipations(List<Participation> participations)
	{
		if (!CanAddParticipation())
		{
			throw new InvalidOperationException("The competition has not been started or its sessions have started");
		}

		ArgumentNullException.ThrowIfNull(participations);

		if (participations.Count == 0)
		{
			throw new ArgumentException("Can not add 0 participations");
		}

		/*If the driver is already participating in the competition, exception*/

		if (participations.DistinctBy(p => p.DriverId).Count() < participations.Count)
		{
			throw new ArgumentException("The same driver can not participate twice in the same competition");
		}

		/*If the participation is for another competition, exception*/

		if (participations.DistinctBy(p => p.CompetitionId).Count() != 1)
		{
			throw new ArgumentException("A participation from other competitions can not be added to this competition");
		}

		/*If participations from more than one competitor are trying to be added, exception*/

		if (participations.DistinctBy(p => p.CompetitorId).Count() != 1)
		{
			throw new ArgumentException("A participation with more than one competitor can not be added");
		}

		/*If the competitor is already participating, exception*/

		if (Participations.Any(p => p.CompetitorId == participations[0].CompetitorId))
		{
			throw new ArgumentException("The competitor already have its participations established for this competition");
		}

		foreach(var participation in participations)
		{
			if(Season is null)
			{
				throw new InvalidOperationException();
			}

			/*If the competitor from a participation is not present in the season competitors, exception*/

			if (!Season.Competitors.Any(c => c.Id == participation.CompetitorId))
			{
				throw new InvalidOperationException();
			}
		}

		foreach(var participation in participations)
		{
			_participations.Add(participation);
		}
	}

	public void Advance()
	{
		if (!CanAdvance())
		{
			if (State.Equals(CompetitionStateEnum.NotStarted))
			{
				throw new InvalidOperationException("Cannot advance a competition that has not started");
			}
			else if (State.Equals(CompetitionStateEnum.Finished))
			{
				throw new InvalidOperationException("Cannot advance a competition that has already finished");
			}
			else if (Participations.Count == 0 || Participations.DistinctBy(p => p.CompetitorId).Count() < Season!.Competitors.Count)
			{
				throw new InvalidOperationException("Cannot advance a competition if there are teams without participations");
			}
		}

		foreach(var session in _sessions)
		{
			if(!session.HasFinished())
			{
				session.Advance();
				if(_sessions.All(s => s.State == SessionStateEnum.Finished))
				{
					State = CompetitionStateEnum.Finished;
				}
				break;
			}
		}
	}

	public void AddIncident(Incident incident, Session session)
	{
		if (_sessions.Any(s => s.Id == session.Id) && session.CanAddIncident())
		{
			session.AddIncident(incident);

			var newIncidentAdded = new IncidentAddedEvent(incident);
			base.RegisterDomainEvent(newIncidentAdded);

		}
		else
		{
			throw new InvalidOperationException("It is not possible to add an incident to the session specified");
		}
	}

	public bool CanAdvance()
	{
		if (!State.Equals(CompetitionStateEnum.Started))
		{
			return false;
		}

		if (Participations.Count == 0 || Participations.DistinctBy(p => p.CompetitorId).Count() < Season!.Competitors.Count)
		{
			return false;
		}

		return true;

	}

	public bool CanAddParticipation()
	{
		return State.Equals(CompetitionStateEnum.Started) && _sessions.All(s => s.State.Equals(SessionStateEnum.NotStarted));

	}

	private void CheckArguments(string name)
	{
		ArgumentException.ThrowIfNullOrEmpty(name);
	}
}
