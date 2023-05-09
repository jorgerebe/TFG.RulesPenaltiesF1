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
         competitorViewModels.Add(CompetitorViewModel.MapEntityToViewModel(competitor)!);
      }

      return competitorViewModels;
   }

	public async Task<List<CompetitorViewModel>> GetAllCompetitorsWithTeamPrincipals()
	{
		var competitors = await _repository.GetAllCompetitorsWithTeamPrincipals();

		List<CompetitorViewModel> competitorViewModels = new();

		foreach (var competitor in competitors)
		{
			competitorViewModels.Add(CompetitorViewModel.MapEntityToViewModel(competitor)!);
		}

		return competitorViewModels;
	}

	public async Task<List<IUser>> GetAllTeamPrincipals()
   {
      List<IUser> teamPrincipals = await _repository.GetTeamPrincipals();

      return teamPrincipals;
   }


   public async Task<CompetitorViewModel?> GetByIdAsync(int id)
   {
      var competitor = await _repository.GetCompetitorById(id);

      if(competitor is null)
      {
         return null;
      }

      CompetitorViewModel competitorViewModel = CompetitorViewModel.MapEntityToViewModel(competitor)!;

      return competitorViewModel;
   }

	public async Task<CompetitorViewModel?> GetCompetitorByTeamPrincipal(string teamPrincipalId)
	{
		var competitor = await _repository.GetCompetitorByTeamPrincipalId(teamPrincipalId);
		if(competitor is null)
		{
			return null;
		}

		return CompetitorViewModel.MapEntityToViewModel(competitor);
	}

   public async Task<bool> ExistsCompetitorWithName(string name)
   {
      return await _repository.ExistsCompetitorByName(name);
   }
}
