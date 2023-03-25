using TFG.RulesPenaltiesF1.Core.Entities;
using TFG.RulesPenaltiesF1.Web.ViewModels;

namespace TFG.RulesPenaltiesF1.Web.Interfaces;

public interface ICircuitViewModelService
{
   Task<List<CountryViewModel>> GetAllCountries();
   Task<List<CircuitViewModel>> GetAllCircuits();
   Task<CircuitViewModel?> GetByIdAsync(int id);

   Circuit? MapViewModelToEntity(CircuitViewModel circuit);
   CircuitViewModel? MapEntityToViewModel(Circuit circuit);
}
