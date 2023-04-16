using TFG.RulesPenaltiesF1.Core.Entities;
using TFG.RulesPenaltiesF1.Core.Entities.Users;
using TFG.RulesPenaltiesF1.Web.ViewModels;

namespace TFG.RulesPenaltiesF1.Web.Interfaces;

public interface ICompetitorViewModelService
{
   Task<List<IUser>> GetAllTeamPrincipals();
   Task<List<CompetitorViewModel>> GetAllCompetitors();
   Task<CompetitorViewModel?> GetByIdAsync(int id);
   Competitor? MapViewModelToEntity(CompetitorViewModel competitor);
   CompetitorViewModel? MapEntityToViewModel(Competitor competitor);
   Task<bool> ExistsCompetitorWithName(string name);
}
