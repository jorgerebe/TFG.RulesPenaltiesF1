﻿using TFG.RulesPenaltiesF1.Core.Entities.CompetitionAggregate;
using TFG.RulesPenaltiesF1.Core.Entities.IncidentAggregate;

namespace TFG.RulesPenaltiesF1.Core.Interfaces.Services;

public interface ICompetitionService
{
	Task<Competition> StartCompetition(int id);
	Task AddParticipations(List<Participation> participations);
	Task AdvanceSession(int id);
	Task AddIncident(Incident incident);
}
