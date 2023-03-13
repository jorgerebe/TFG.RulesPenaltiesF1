 using TFG.RulesPenaltiesF1.Core.Interfaces;
using TFG.RulesPenaltiesF1.Web.Interfaces;
using TFG.RulesPenaltiesF1.Web.ViewModels.Penalties;

namespace TFG.RulesPenaltiesF1.Web.Services;

public class PenaltyViewModelService : IPenaltyViewModelService
{
   private readonly IPenaltyRepository _repository;

   public PenaltyViewModelService(IPenaltyRepository repository)
   {
      _repository = repository;
   }

   public async Task<List<PenaltyViewModel>> GetPenaltiesAsync()
   {
      var penalties = await _repository.GetAllPenalties();

      List<PenaltyViewModel> penaltiesViewModel = new List<PenaltyViewModel>();

      foreach(var penalty in penalties)
      {
         penaltiesViewModel.Add(PenaltyViewModelFactory.CreateViewModel(penalty));
      }

      return penaltiesViewModel;
   }
}
