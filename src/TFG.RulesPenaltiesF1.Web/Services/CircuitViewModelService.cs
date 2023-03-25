using TFG.RulesPenaltiesF1.Core.Entities;
using TFG.RulesPenaltiesF1.Core.Interfaces;
using TFG.RulesPenaltiesF1.Web.Interfaces;
using TFG.RulesPenaltiesF1.Web.ViewModels;

namespace TFG.RulesPenaltiesF1.Web.Services;

public class CircuitViewModelService : ICircuitViewModelService
{
   private readonly IRepository<Circuit> _circuitRepository;
   private readonly IRepository<Country> _countryRepository;
   public CircuitViewModelService(IRepository<Circuit> circuitRepository, IRepository<Country> countryRepository)
   {
      _circuitRepository = circuitRepository;
      _countryRepository = countryRepository;
   }

   public async Task<List<CircuitViewModel>> GetAllCircuits()
   {
      var circuits = await _circuitRepository.GetAllAsync();

      return new List<CircuitViewModel>();
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

      var circuit = await _circuitRepository.GetByIdAsync(id);

      return new CircuitViewModel();
   }

   public CircuitViewModel? MapEntityToViewModel(Circuit circuit)
   {
      throw new NotImplementedException();
   }

   public Circuit? MapViewModelToEntity(CircuitViewModel circuit)
   {
      throw new NotImplementedException();
   }
}
