using TFG.RulesPenaltiesF1.Core.Entities.Penalties;

namespace TFG.RulesPenaltiesF1.Core.Entities.CompetitionAggregate;

public class Incident : EntityBase
{
	public DateTime Created { get; set; }

	public Participation? Participation { get; set; }
	public int ParticipationId { get; set; }

	public Session? Session { get; set; }
	public int SessionId { get; set; }

	public string Fact { get; set; } = string.Empty;

	public Article? Article { get; set; }
	public int ArticleId { get; set; }

	public Penalty? Penalty { get; set; }
	public int PenaltyId { get; set; }

	public string Reason = string.Empty;

	private Incident()
	{

	}

	public Incident(DateTime created, Participation participation, Session session, string fact, Article article, Penalty penalty,
		string reason)
	{
		ArgumentNullException.ThrowIfNull(created);
		ArgumentNullException.ThrowIfNull(participation);
		ArgumentNullException.ThrowIfNull(session);
		ArgumentNullException.ThrowIfNull(article);
		ArgumentNullException.ThrowIfNull(penalty);

		ArgumentException.ThrowIfNullOrEmpty(fact);
		ArgumentException.ThrowIfNullOrEmpty(reason);

		Created = created;
		Participation = participation;
		ParticipationId = participation.Id;
		Session = session;
		SessionId = session.Id;
		Fact = fact;
		Article = article;
		ArticleId = article.Id;
		Penalty = penalty;
		PenaltyId = penalty.Id;
	}

	public Incident(DateTime created, int participationId, int sessionId, string fact, int articleId, int penaltyId,
		string reason)
	{
		ArgumentNullException.ThrowIfNull(created);

		ArgumentException.ThrowIfNullOrEmpty(fact);
		ArgumentException.ThrowIfNullOrEmpty(reason);

		Created = created;
		ParticipationId = participationId;
		SessionId = sessionId;
		Fact = fact;
		ArticleId = articleId;
		PenaltyId = penaltyId;
		Reason = reason;
	}
}
