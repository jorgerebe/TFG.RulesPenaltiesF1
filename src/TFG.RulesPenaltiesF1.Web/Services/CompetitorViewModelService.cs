using TFG.RulesPenaltiesF1.Core.Entities;
using TFG.RulesPenaltiesF1.Core.Entities.Users;
using TFG.RulesPenaltiesF1.Core.Interfaces.Repositories;
using TFG.RulesPenaltiesF1.Web.Interfaces;
using TFG.RulesPenaltiesF1.Web.ViewModels;

namespace TFG.RulesPenaltiesF1.Web.Services;

public class CompetitorViewModelService : ICompetitorViewModelService
{

   private readonly ICompetitorRepository _repository;
   public CompetitorViewModelService(ICompetitorRepository repository)
   {
      _repository = repository;
   }

   public async Task<List<CompetitorViewModel>> GetAllCompetitors()
   {
      var competitors = await _repository.GetAllAsync();


      List<CompetitorViewModel> competitorViewModels = new ();

      foreach(var competitor in competitors)
      {
         competitorViewModels.Add(MapEntityToViewModel(competitor)!);
      }

      return competitorViewModels;
   }

   public async Task<List<IUser>> GetAllTeamPrincipals()
   {
      List<IUser> teamPrincipals = new();
      teamPrincipals = await _repository.GetTeamPrincipals();

      return teamPrincipals;
   }


   public async Task<CompetitorViewModel?> GetByIdAsync(int id)
   {
      var competitor = await _repository.GetCompetitorById(id);

      if(competitor is null)
      {
         return null;
      }

      CompetitorViewModel competitorViewModel = MapEntityToViewModel(competitor)!;

      return competitorViewModel;
   }


   public CompetitorViewModel? MapEntityToViewModel(Competitor competitor)
   {
      ArgumentNullException.ThrowIfNull(competitor);

      CompetitorViewModel competitorViewModel = new()
      {
         Id = competitor.Id,
         Name = competitor.Name,
         Location = competitor.Location,
         TeamPrincipalName = (competitor.TeamPrincipal != null) ? competitor.TeamPrincipal.FullName : "",
         PowerUnit = competitor.PowerUnit
      };

      return competitorViewModel;
   }

   public Competitor? MapViewModelToEntity(CompetitorViewModel competitor)
   {
      ArgumentNullException.ThrowIfNull(competitor);

      Competitor competitorEntity = new Competitor(competitor.Name, competitor.Location, competitor.TeamPrincipalId!, competitor.PowerUnit);

      return competitorEntity;
   }

   public async Task<bool> ExistsCompetitorWithName(string name)
   {
      return await _repository.ExistsCompetitorByName(name);
   }
}
