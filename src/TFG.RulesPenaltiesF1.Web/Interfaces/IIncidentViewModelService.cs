using TFG.RulesPenaltiesF1.Web.ViewModels;

namespace TFG.RulesPenaltiesF1.Web.Interfaces;

public interface IIncidentViewModelService
{
	Task<List<IncidentViewModel>> GetIncidents(int? driver, int? session);
}
