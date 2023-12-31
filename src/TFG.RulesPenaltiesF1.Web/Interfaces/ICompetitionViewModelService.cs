﻿using TFG.RulesPenaltiesF1.Web.ViewModels;

namespace TFG.RulesPenaltiesF1.Web.Interfaces;

public interface ICompetitionViewModelService
{
	Task<CompetitionViewModel?> GetByIdAsync(int id);
	Task<bool> CanStartCompetition(int id);
	Task<bool> CanAddParticipation(int idCompetition, string idTeamPrincipal);
	Task<bool> CanAdvanceSession(int id);
	Task<bool> CanAddIncident(int id);
	Task<CompetitionViewModel?> GetBySessionId(int sessionId);
}
