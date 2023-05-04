using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TFG.RulesPenaltiesF1.Core.Entities.CompetitionAggregate;
using TFG.RulesPenaltiesF1.Core.Interfaces.Services;
using TFG.RulesPenaltiesF1.Infrastructure.Identity;
using TFG.RulesPenaltiesF1.Web.Interfaces;
using TFG.RulesPenaltiesF1.Web.ViewModels;

namespace TFG.RulesPenaltiesF1.Web.Controllers;

public class CompetitionsController : Controller
{
	private readonly ICompetitionViewModelService _viewModelService;
	private readonly ICompetitionService _service;
	private readonly UserManager<ApplicationUser> _userManager;

	public CompetitionsController(ICompetitionViewModelService viewModelService, ICompetitionService service,
		UserManager<ApplicationUser> userManager)
	{
		_viewModelService = viewModelService;
		_service = service;
		_userManager = userManager;
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
	[Authorize(Roles ="Steward")]
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

	// POST: Competitions/StartCompetition/5
	[HttpPost]
	[Authorize(Roles ="TeamPrincipal")]
	public async Task<IActionResult> AddParticipations(int? id)
   {
      if (id == null)
      {
         return NotFound();
      }

		CompetitionViewModel? competition = await _viewModelService.GetByIdAsync((int)id);

		if(competition is null)
		{
			return NotFound();
		}

		bool anySessionStarted = false;

		foreach(var session in competition.Sessions)
		{
			if (!session.State.Equals(SessionStateEnum.NotStarted))
			{
				anySessionStarted = true;
			}
		}

		if(anySessionStarted)
		{
			return NotFound();
		}

		/*Está el equipo compitiendo en la temporada? El equipo ya tiene participaciones registradas?
		 Cuales son los pilotos del equipo?*/

		var currentUser = await _userManager.GetUserAsync(HttpContext.User);
		//currentUser.R

		return View("Details", await _viewModelService.GetByIdAsync((int)id));
   }
}
