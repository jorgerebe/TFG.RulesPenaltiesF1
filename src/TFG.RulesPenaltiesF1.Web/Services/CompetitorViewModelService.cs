using TFG.RulesPenaltiesF1.Core.Entities;
using TFG.RulesPenaltiesF1.Core.Entities.Users;
using TFG.RulesPenaltiesF1.Core.Interfaces.Repositories;
using TFG.RulesPenaltiesF1.Infrastructure.Identity;
using TFG.RulesPenaltiesF1.Web.Interfaces;
using Microsoft.AspNetCore.Identity;
using TFG.RulesPenaltiesF1.Web.ViewModels;
using TFG.RulesPenaltiesF1.Infrastructure.Data;

namespace TFG.RulesPenaltiesF1.Web.Services;

public class CompetitorViewModelService : ICompetitorViewModelService
{
   private readonly UserManager<ApplicationUser> _userManager;
   private readonly RoleManager<IdentityRole> _roleManager;
   private readonly IRepository<Competitor> _repository;
   public CompetitorViewModelService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IRepository<Competitor> repository)
   {
      _userManager = userManager;
      _roleManager = roleManager;
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
      List<IUser> TeamPrincipals = new();

      var role = await _roleManager.FindByNameAsync(UserRole.TeamPrincipal.ToString());
      if (role == null)
      {
         // handle role not found
         return TeamPrincipals;
      }

      var users = await _userManager.GetUsersInRoleAsync(role.Name!);

      foreach (var user in users)
      {
         TeamPrincipals.Add(user);
      }

      return TeamPrincipals;
   }

   public Task<CircuitViewModel?> GetByIdAsync(int id)
   {
      throw new NotImplementedException();
   }

   Task<CompetitorViewModel?> ICompetitorViewModelService.GetByIdAsync(int id)
   {
      throw new NotImplementedException();
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
}
