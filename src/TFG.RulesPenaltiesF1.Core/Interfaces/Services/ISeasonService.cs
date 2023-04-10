using TFG.RulesPenaltiesF1.Core.Entities;

namespace TFG.RulesPenaltiesF1.Core.Interfaces.Services;

public interface ISeasonService
{
	Task CreateSeasonAsync(Season season);
}
