using TFG.RulesPenaltiesF1.Core.Entities.RegulationAggregate;
using TFG.RulesPenaltiesF1.Core.Interfaces.Repositories;
using TFG.RulesPenaltiesF1.Web.Interfaces;
using TFG.RulesPenaltiesF1.Web.ViewModels;
using TFG.RulesPenaltiesF1.Web.ViewModels.Penalties;

namespace TFG.RulesPenaltiesF1.Web.Services;

public class RegulationViewModelService : IRegulationViewModelService
{
   private readonly IRegulationRepository _repository;

   public RegulationViewModelService(IRegulationRepository repository)
   {
      _repository = repository;
   }

   public async Task<RegulationViewModel?> GetRegulationByIdAsync(int id)
   {
      var regulation = await _repository.GetRegulationByIdAsync(id);

      if(regulation is null)
      {
         return null;
      }

      return RegulationViewModel.MapEntityToViewModel(regulation);
   }

   public async Task<List<RegulationViewModel>> GetRegulationsAsync()
   {
      var regulations = await _repository.GetAllAsync();

      var regulationsViewModel = new List<RegulationViewModel>();

      foreach(var regulation in regulations)
      {
         regulationsViewModel.Add(new RegulationViewModel()
         {
            Id = regulation.Id,
            Name = regulation.Name
         });
      }

      return regulationsViewModel;
   }

   public async Task<bool> ExistsRegulationWithName(string name)
   {
      return await _repository.ExistsRegulationByName(name);
   }

	public async Task<RegulationViewModel?> GetRegulationByCompetitionId(int competitionId)
	{
		Regulation? regulation = await _repository.GetRegulationByCompetitionId(competitionId);

		if(regulation is null)
		{
			return null;
		}

		return RegulationViewModel.MapEntityToViewModel(regulation);
	}
}
