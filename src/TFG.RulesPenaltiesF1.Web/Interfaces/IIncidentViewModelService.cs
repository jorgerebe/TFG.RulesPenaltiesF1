using TFG.RulesPenaltiesF1.Web.ViewModels;

namespace TFG.RulesPenaltiesF1.Web.Interfaces;

public interface IIncidentViewModelService
{
	Task<List<IncidentViewModel>> GetIncidents(string sortOrder, int? driver, int? session);
	Task<IncidentViewModel?> GetIncidentById(int? id);
}
