using TFG.RulesPenaltiesF1.Core.Entities;
using TFG.RulesPenaltiesF1.Core.Interfaces.Repositories;
using TFG.RulesPenaltiesF1.Web.Interfaces;
using TFG.RulesPenaltiesF1.Web.ViewModels;

namespace TFG.RulesPenaltiesF1.Web.Services;

public class CircuitViewModelService : ICircuitViewModelService
{
   private readonly ICircuitRepository _circuitRepository;
   private readonly IRepository<Country> _countryRepository;
   public CircuitViewModelService(ICircuitRepository circuitRepository, IRepository<Country> countryRepository)
   {
      _circuitRepository = circuitRepository;
      _countryRepository = countryRepository;
   }

   public async Task<List<CircuitViewModel>> GetAllCircuits()
   {
      var circuits = await _circuitRepository.GetAllCircuits();

      List<CircuitViewModel> circuitsViewModel = new ();

      foreach(var circuit in circuits)
      {
         circuitsViewModel.Add(CircuitViewModel.MapEntityToViewModel(circuit)!);
      }

      return circuitsViewModel;
   }

   public async Task<List<CountryViewModel>> GetAllCountries()
   {
      var countries = await _countryRepository.GetAllAsync();

      List<CountryViewModel> countriesViewModel = new();

      foreach(var country in countries)
      {
         countriesViewModel.Add(new()
         {
            Id = country.Id,
            Name = country.Name
         });
      }

      return countriesViewModel;
   }

   public async Task<CircuitViewModel?> GetByIdAsync(int id)
   {

      var circuit = await _circuitRepository.GetCircuitById(id);

      if(circuit is null)
      {
         return null;
      }

      var circuitViewModel = CircuitViewModel.MapEntityToViewModel(circuit);

      return circuitViewModel;
   }

}
