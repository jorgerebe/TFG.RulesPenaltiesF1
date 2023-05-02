namespace TFG.RulesPenaltiesF1.Core.Entities.CompetitionAggregate;

public class Session : EntityBase
{
	public Competition? Competition { get; set; }
	public int CompetitionId { get; set; }

	public SessionStateEnum State { get; set; }
	public SessionTypeEnum? SessionType { get; set; }

	private Session(int competitionId)
	{
		CompetitionId = competitionId;
		State = SessionStateEnum.NotStarted;
	}

	public Session(int competitionId, SessionTypeEnum type)
	{
		CompetitionId = competitionId;
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
}
