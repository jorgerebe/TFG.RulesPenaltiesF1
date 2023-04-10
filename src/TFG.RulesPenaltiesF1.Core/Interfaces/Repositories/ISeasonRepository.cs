using TFG.RulesPenaltiesF1.Core.Entities;

namespace TFG.RulesPenaltiesF1.Core.Interfaces.Repositories;

public interface ISeasonRepository : IRepository<Season>
{
	public Task<Season?> GetSeasonByYear(int year);
}
