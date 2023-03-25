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
         circuitsViewModel.Add(MapEntityToViewModel(circuit)!);
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

      var circuitViewModel = MapEntityToViewModel(circuit);

      return circuitViewModel;
   }

   public CircuitViewModel? MapEntityToViewModel(Circuit circuit)
   {
      if(circuit == null)
      {
         return null;
      }



      return new CircuitViewModel()
      {
         Id = circuit.Id,
         Country = new CountryViewModel() { Id = circuit.Country!.Id, Name = circuit.Country.Name },
         Name = circuit.Name,
         Length = circuit.Length,
         Laps = circuit.Laps,
         RaceDistance = circuit.Length * circuit.Laps,
         YearFirstGP = circuit.YearFirstGP,
         MillisecondsLapRecord = circuit.MillisecondsLapRecord,
         DriverLapRecord = circuit.DriverLapRecord,
         YearLapRecord = circuit.YearLapRecord,
         InfoLapRecord = circuit.FormatFastLap() + " - " + circuit.DriverLapRecord + " (" + circuit.YearLapRecord + ")"
      };
   }

   public Circuit? MapViewModelToEntity(CircuitViewModel circuit)
   {
      if(circuit is null)
      {
         return null;
      }

      Circuit circuitEntity = new Circuit(circuit.CountryId, circuit.Name, circuit.Length,
         circuit.Laps, circuit.YearFirstGP, circuit.MillisecondsLapRecord, circuit.DriverLapRecord, circuit.YearFirstGP);

      return circuitEntity;
   }

}
