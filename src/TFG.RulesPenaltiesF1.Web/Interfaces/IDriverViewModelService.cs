using TFG.RulesPenaltiesF1.Core.Entities;
using TFG.RulesPenaltiesF1.Web.ViewModels;

namespace TFG.RulesPenaltiesF1.Web.Interfaces;

public interface IDriverViewModelService
{
	Task<List<DriverViewModel>> GetAllDrivers();
	Task<DriverViewModel?> GetDriverById(int id);

	Driver? MapViewModelToEntity(DriverViewModel driver);
	DriverViewModel? MapEntityToViewModel(Driver driver);
}
