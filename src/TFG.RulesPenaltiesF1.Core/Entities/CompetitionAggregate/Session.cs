namespace TFG.RulesPenaltiesF1.Core.Entities.CompetitionAggregate;

public class Session : EntityBase
{
	public Competition? Competition { get; set; }
	public int CompetitionId { get; set; }

	public bool Finished { get; set; }
	public SessionTypeEnum? SessionType { get; set; }

	private Session(int competitionId)
	{
		CompetitionId = competitionId;
		Finished = false;
	}

	public Session(int competitionId, SessionTypeEnum type)
	{
		CompetitionId = competitionId;
		Finished = false;
		SessionType = type;
	}

	public void Finish()
	{
		if (Finished)
		{
			throw new InvalidOperationException("The session is already finished");
		}

		Finished = true;
	}
}
