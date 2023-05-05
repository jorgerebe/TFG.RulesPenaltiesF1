using TFG.RulesPenaltiesF1.Core.Entities;
using TFG.RulesPenaltiesF1.Core.Entities.Users;
using TFG.RulesPenaltiesF1.Web.ViewModels;

namespace TFG.RulesPenaltiesF1.Web.Interfaces;

public interface ICompetitorViewModelService
{
   Task<List<IUser>> GetAllTeamPrincipals();
   Task<List<CompetitorViewModel>> GetAllCompetitors();
	Task<List<CompetitorViewModel>> GetAllCompetitorsWithTeamPrincipals();
   Task<CompetitorViewModel?> GetByIdAsync(int id);
	Task<CompetitorViewModel?> GetCompetitorByTeamPrincipal(string teamPrincipalId);
   Task<bool> ExistsCompetitorWithName(string name);
}
