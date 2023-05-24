using TFG.RulesPenaltiesF1.Core.Entities.CompetitionAggregate;
using TFG.RulesPenaltiesF1.Core.Entities.Penalties;
using TFG.RulesPenaltiesF1.Core.Interfaces;

namespace TFG.RulesPenaltiesF1.Core.Entities;

public class Incident : EntityBase, IAggregateRoot
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
	public int? PenaltyId { get; set; }

	public string Reason = string.Empty;

	public int? LicensePoints { get; set; }
	public float? Fine { get; set; }

	private Incident()
	{

	}

	public Incident(DateTime created, Participation participation, Session session, string fact, Article article, Penalty penalty,
		string reason, int? licensePoints, float? fine)
	{
		ArgumentNullException.ThrowIfNull(created);
		ArgumentNullException.ThrowIfNull(participation);
		ArgumentNullException.ThrowIfNull(session);
		ArgumentNullException.ThrowIfNull(article);

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

		if (penalty is not null)
		{
			PenaltyId = penalty.Id;
		}

		if(licensePoints is not null)
		{
			if(licensePoints < 0 || licensePoints > 6)
			{
				throw new ArgumentException("Negative points can not be added and no more than 6 license points can be added");
			}
		}

		if(fine is not null)
		{
			if(fine < 0)
			{
				throw new ArgumentException("Fine must be a positive number");
			}
		}
	}

	public Incident(DateTime created, int participationId, int sessionId, string fact, int articleId, int? penaltyId,
		string reason, int? licensePoints, float? fine)
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

		if (licensePoints is not null)
		{

			if (licensePoints <= 0 || licensePoints > 6)
			{
				throw new ArgumentException("Negative points can not be added and no more than 6 license points can be added");
			}

			LicensePoints = licensePoints;
		}

		if (fine is not null)
		{
			if (fine <= 0)
			{
				throw new ArgumentException("Fine must be a positive number");
			}

			Fine = fine;
		}
	}
}
