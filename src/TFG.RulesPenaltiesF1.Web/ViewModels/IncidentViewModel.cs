﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TFG.RulesPenaltiesF1.Core.Entities;
using TFG.RulesPenaltiesF1.Core.Entities.Penalties;

namespace TFG.RulesPenaltiesF1.Web.ViewModels;

public class IncidentViewModel
{
	public int Id { get; set; }

	public int CompetitionId { get; set; }

	public DateTime Created { get; set; }

	[Required]
	[DisplayName("Driver")]
	public int ParticipationId { get; set; }

	public ParticipationViewModel? Participation { get; set; }

	public int SessionId { get; set; }

	public SessionViewModel? Session { get; set; }

	[Required]
	public string Fact { get; set; } = string.Empty;

	[Required]
	[DisplayName("Infringment")]
	public int ArticleId { get; set; }

	public ArticleViewModel? Article { get; set; }

	[Required]
	[DisplayName("Decission")]
	public int PenaltyId { get; set; }

	public Penalty? Penalty { get; set; }

	[Required]
	public string Reason { get; set; } = string.Empty;

	[Required]
	[Range(0, 6, ErrorMessage = "A maximum of 6 license points can be added to a driver")]
	public int LicensePoints { get; set; }

	[Required]
	[Range(0, 100000, ErrorMessage ="The maximum value for the fine is 100 0000")]
	public float Fine { get; set; }

	public static Incident MapViewModelToEntity(IncidentViewModel viewModel)
	{
		int? licensePoints = null;
		float? fine = null;
		int? penaltyId = null;

		if(viewModel.LicensePoints != 0)
		{
			licensePoints = viewModel.LicensePoints;
		}
		if(viewModel.Fine != 0)
		{
			fine = viewModel.Fine;
		}
		if(viewModel.PenaltyId != -1)
		{
			penaltyId = viewModel.PenaltyId;
		}

		Incident incident = new(viewModel.Created, viewModel.ParticipationId, viewModel.SessionId, viewModel.Fact,
			viewModel.ArticleId, penaltyId, viewModel.Reason, licensePoints, fine);

		return incident;
	}

}
