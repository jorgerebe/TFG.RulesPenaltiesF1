using TFG.RulesPenaltiesF1.Core.Entities.IncidentAggregate;

namespace TFG.RulesPenaltiesF1.Core.Entities.CompetitionAggregate;

public class Session : EntityBase
{
	public Competition? Competition { get; private set; }
	public int CompetitionId { get; private set; }

	public SessionStateEnum State { get; private set; }
	public SessionTypeEnum? SessionType { get; private set; }

	private readonly List<Incident> _incidents = new();
	public IReadOnlyCollection<Incident> Incidents => _incidents.AsReadOnly();

	private Session(int competitionId)
	{
		CompetitionId = competitionId;
		State = SessionStateEnum.NotStarted;
	}

	public Session(Competition competition, SessionTypeEnum type)
	{
		ArgumentNullException.ThrowIfNull(competition);
		ArgumentNullException.ThrowIfNull(type);

		Competition = competition;
		CompetitionId = competition.Id;
		State = SessionStateEnum.NotStarted;
		SessionType = type;
	}

	public void Advance()
	{
		if (State.Equals(SessionStateEnum.Finished))
		{
			throw new InvalidOperationException("The session is already finished");
		}
		else if (State.Equals(SessionStateEnum.NotStarted))
		{
			State = SessionStateEnum.Started;
		}
		else if (State.Equals(SessionStateEnum.Started))
		{
			State = SessionStateEnum.Finished;
		}
	}

	public bool HasFinished()
	{
		return State.Equals(SessionStateEnum.Finished);
	}

	public bool CanAddIncident()
	{
		return State.Equals(SessionStateEnum.Started);
	}

	public void AddIncident(Incident incident)
	{
		ArgumentNullException.ThrowIfNull(incident);

		if(!CanAddIncident())
		{
			throw new InvalidOperationException();
		}

		_incidents.Add(incident);
	}
}
