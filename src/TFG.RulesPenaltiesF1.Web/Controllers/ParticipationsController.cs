using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TFG.RulesPenaltiesF1.Infrastructure.Identity;
using TFG.RulesPenaltiesF1.Web.Interfaces;
using TFG.RulesPenaltiesF1.Web.ViewModels;

namespace TFG.RulesPenaltiesF1.Web.Controllers;

public class ParticipationsController : Controller
{
	private readonly UserManager<ApplicationUser> _userManager;
	private readonly ICompetitionViewModelService _competitionViewModelService;
	private readonly IDriverViewModelService _driverViewModelService;
	private readonly ICompetitorViewModelService _competitorViewModelService;

	public ParticipationsController(UserManager<ApplicationUser> userManager, ICompetitionViewModelService competitionViewModelService,
		IDriverViewModelService driverViewModelService, ICompetitorViewModelService competitorViewModelService)
	{
		_userManager = userManager;
		_competitionViewModelService = competitionViewModelService;
		_driverViewModelService = driverViewModelService;
		_competitorViewModelService = competitorViewModelService;
	}

	[HttpGet]
	[Authorize(Roles = "TeamPrincipal")]
	public async Task<IActionResult> Create(int? id)
	{
		if(id is null)
		{
			return NotFound();
		}

		var currentUser = await _userManager.GetUserAsync(HttpContext.User);

		if(currentUser is null)
		{
			return NotFound();
		}

		if(!await _competitionViewModelService.CanAddParticipation((int)id, currentUser.Id))
		{
			return NotFound();
		}

		var competition = await _competitionViewModelService.GetByIdAsync((int)id);
		var competitor = await _competitorViewModelService.GetCompetitorByTeamPrincipal(currentUser.Id);

		if(competitor is null || competition is null)
		{
			return NotFound();
		}

		ParticipationInputViewModel participationInput = new()
		{
			CompetitionId = (int)id,
			Competition = competition,
			CompetitorId = competitor.Id,
			Competitor = competitor
		};

		var drivers = await _driverViewModelService.GetDriversInCompetitor(competitor.Id);

		ViewBag.Drivers = drivers.AsEnumerable();

		return View(participationInput);
	}
}
