using TFG.RulesPenaltiesF1.Core.Entities;
using TFG.RulesPenaltiesF1.Core.Interfaces.Repositories;
using TFG.RulesPenaltiesF1.Web.Interfaces;
using TFG.RulesPenaltiesF1.Web.ViewModels;

namespace TFG.RulesPenaltiesF1.Web.Services;

public class SeasonViewModelService : ISeasonViewModelService
{

   public SeasonViewModelService()
   {
   }

   public Task<SeasonViewModel?> GetByIdAsync(int id)
   {
      throw new NotImplementedException();
   }
}
