using Microsoft.AspNetCore.Mvc;
using TFG.RulesPenaltiesF1.Web.Interfaces;

namespace TFG.RulesPenaltiesF1.Web.Controllers;

public class CompetitionsController : Controller
{
	private readonly ICompetitionViewModelService _viewModelService;

	public CompetitionsController(ICompetitionViewModelService viewModelService)
	{
		_viewModelService = viewModelService;
	}

	// GET: Competitions/Details/5
	public async Task<IActionResult> Details(int? id)
   {
      if (id == null)
      {
         return NotFound();
      }

		var competition = await _viewModelService.GetByIdAsync((int)id);

		if(competition is null)
		{
			return NotFound();
		}
		
		return View(competition);
   }
}
