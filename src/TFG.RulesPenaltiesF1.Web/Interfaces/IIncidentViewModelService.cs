using TFG.RulesPenaltiesF1.Web.ViewModels;

namespace TFG.RulesPenaltiesF1.Web.Interfaces;

public interface IIncidentViewModelService
{
	Task<PaginatedList<IncidentViewModel>> GetIncidents(string sortOrder, int? driver, int? session, int pageIndex, int pageSize);
	Task<IncidentViewModel?> GetIncidentById(int? id);
}
