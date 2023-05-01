using Microsoft.AspNetCore.Mvc;
using TFG.RulesPenaltiesF1.Core.Interfaces.Services;
using TFG.RulesPenaltiesF1.Web.Interfaces;

namespace TFG.RulesPenaltiesF1.Web.Controllers;

public class CompetitionsController : Controller
{
	private readonly ICompetitionViewModelService _viewModelService;
	private readonly ICompetitionService _service;

	public CompetitionsController(ICompetitionViewModelService viewModelService, ICompetitionService service)
	{
		_viewModelService = viewModelService;
		_service = service;
	}

	// GET: Competitions/Details/5
	[HttpGet]
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

	// POST: Competitions/StartCompetition/5
	[HttpPost]
	public async Task<IActionResult> StartCompetition(int? id)
   {
      if (id == null)
      {
         return NotFound();
      }

		if (!await _viewModelService.CanStartCompetition((int)id))
		{
			return NotFound();
		}

		await _service.StartCompetition((int)id);

		return View("Details", await _viewModelService.GetByIdAsync((int)id));
   }
}
