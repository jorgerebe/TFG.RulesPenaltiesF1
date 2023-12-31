﻿using TFG.RulesPenaltiesF1.Core.Entities;
using TFG.RulesPenaltiesF1.Core.Entities.Users;

namespace TFG.RulesPenaltiesF1.Core.Interfaces.Repositories;

public interface ICompetitorRepository : IRepository<Competitor>
{
   Task<Competitor?> GetCompetitorById(int id);
   Task<List<IUser>> GetTeamPrincipals();
	Task<List<Competitor>> GetAllCompetitorsWithTeamPrincipals();
	Task<bool> ExistsCompetitorByName(string name);
	Task<Competitor?> GetCompetitorByTeamPrincipalId(string teamPrincipalId);
}
