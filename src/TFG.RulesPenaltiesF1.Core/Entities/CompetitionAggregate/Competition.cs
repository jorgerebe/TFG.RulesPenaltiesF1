using TFG.RulesPenaltiesF1.Core.Interfaces;

namespace TFG.RulesPenaltiesF1.Core.Entities.CompetitionAggregate;

public class Competition : EntityBase, IAggregateRoot
{
	public Season? Season { get; set; }
	public int SeasonId { get; set; }

	public Circuit? Circuit { get; set; }
	public int CircuitId { get; set; }

	public CompetitionStateEnum CompetitionState { get; set; }

	public string Name { get; set; } = string.Empty;
	public bool IsSprint { get; set; }
	public int Week { get; set; }

	private List<Session> _sessions = new();
	public IReadOnlyCollection<Session> Sessions => _sessions.AsReadOnly();

	public List<Participation> _participations = new();
	public IReadOnlyCollection<Participation> Participations => _participations.AsReadOnly();

	public Competition(Circuit circuit, string name, bool isSprint, int week)
	{
		ArgumentNullException.ThrowIfNull(circuit, nameof(circuit));
		ArgumentException.ThrowIfNullOrEmpty(name, nameof(name));

		Circuit = circuit;
		CircuitId = circuit.Id;

		Name = name;
		IsSprint = isSprint;
		Week = week;
		CompetitionState = CompetitionStateEnum.NotStarted;
	}

	public Competition(int circuitId, string name, bool isSprint, int week)
	{
		ArgumentException.ThrowIfNullOrEmpty(name, nameof(name));

		CircuitId = circuitId;

		Name = name;
		IsSprint = isSprint;
		Week = week;
		CompetitionState = CompetitionStateEnum.NotStarted;
	}

	public void StartCompetition()
	{
		if (!CompetitionState.Equals(CompetitionStateEnum.NotStarted))
		{
			throw new InvalidOperationException();
		}

		CompetitionState = CompetitionStateEnum.Started;

		_sessions.Add(new (this.Id, SessionTypeEnum.Practice));
		_sessions.Add(new (this.Id, SessionTypeEnum.Qualifying));

		if (IsSprint)
		{
			_sessions.Add(new Session(this.Id, SessionTypeEnum.SprintShootout));
			_sessions.Add(new Session(this.Id, SessionTypeEnum.Sprint));
		}

		_sessions.Add(new Session(this.Id, SessionTypeEnum.Race));
	}

	public void AddParticipations(List<Participation> participations)
	{
		ArgumentNullException.ThrowIfNull(participations);

		if (participations.Count == 0)
		{
			throw new ArgumentException("Can not add 0 participations");
		}

		if (participations.DistinctBy(p => p.DriverId).Count() < participations.Count)
		{
			throw new ArgumentException("The same driver can not participate twice in the same competition");
		}

		if (participations.DistinctBy(p => p.CompetitionId).Count() != 1)
		{
			throw new ArgumentException("A participation from other competitions can not be added to this competition");
		}

		if (participations.DistinctBy(p => p.CompetitorId).Count() != 1)
		{
			throw new ArgumentException("A participation with more than one competitor can not be added");
		}

		if (Participations.Any(p => p.CompetitorId == participations[0].CompetitorId))
		{
			throw new ArgumentException("The competitor already have its participations established for this competition");
		}

		foreach(var participation in participations)
		{
			_participations.Add(participation);
		}
	}

	public void Advance()
	{
		if(_sessions.Count == 0 || CompetitionState.Equals(CompetitionStateEnum.NotStarted))
		{
			throw new InvalidOperationException("Cannot advance a competition that has not started");
		}

		if(_sessions.All(s => s.State.Equals(SessionStateEnum.Finished)) || CompetitionState.Equals(CompetitionStateEnum.Finished))
		{
			throw new InvalidOperationException("Cannot advance a competition that has already finished");
		}

		foreach(var session in _sessions)
		{
			if(!session.HasFinished())
			{
				session.Advance();
				if(_sessions.All(s => s.State == SessionStateEnum.Finished))
				{
					CompetitionState = CompetitionStateEnum.Finished;
				}
				break;
			}
		}
	}

	public bool CanAdvance()
	{
		if (_sessions.Count == 0 || CompetitionState.Equals(CompetitionStateEnum.NotStarted))
		{
			return false;
		}

		if (_sessions.All(s => s.State.Equals(SessionStateEnum.Finished)) || CompetitionState.Equals(CompetitionStateEnum.Finished))
		{
			return false;
		}

		var total = Participations.DistinctBy(p => p.CompetitorId).Count();

		if (Participations.DistinctBy(p => p.CompetitorId).Count() < Season!.Competitors.Count)
		{
			return false;
		}

		return true;

	}
}
