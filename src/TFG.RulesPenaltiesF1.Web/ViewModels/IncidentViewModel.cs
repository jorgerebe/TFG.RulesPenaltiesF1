using System.ComponentModel.DataAnnotations;
using TFG.RulesPenaltiesF1.Core.Entities.CompetitionAggregate;
using TFG.RulesPenaltiesF1.Core.Entities.Penalties;

namespace TFG.RulesPenaltiesF1.Web.ViewModels;

public class IncidentViewModel
{
	public int Id { get; set; }

	public int CompetitionId { get; set; }

	public DateTime Created { get; set; }

	[Required]
	public int ParticipationId { get; set; }

	public ParticipationViewModel? Participation { get; set; }

	public int SessionId { get; set; }

	public SessionViewModel? Session { get; set; }

	[Required]
	public string Fact { get; set; } = string.Empty;

	[Required]
	public int ArticleId { get; set; }

	public ArticleViewModel? Article { get; set; }

	[Required]
	public int PenaltyId { get; set; }

	public Penalty? Penalty { get; set; }

	[Required]
	public string Reason = string.Empty;

	public static Incident MapViewModelToEntity(IncidentViewModel viewModel)
	{
		Incident incident = new(viewModel.Created, viewModel.ParticipationId, viewModel.SessionId, viewModel.Fact,
			viewModel.ArticleId, viewModel.PenaltyId, viewModel.Reason);

		return incident;
	}

}
