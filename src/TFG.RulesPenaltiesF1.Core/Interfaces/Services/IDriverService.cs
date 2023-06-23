using TFG.RulesPenaltiesF1.Core.Entities;

namespace TFG.RulesPenaltiesF1.Core.Interfaces.Services;

public interface IDriverService
{
	Task CreateDriverAsync(Driver driver);
	Task UpdateDriverAsync(Driver driver);
}
