using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using TFG.RulesPenaltiesF1.Core.Interfaces.Services;
using TFG.RulesPenaltiesF1.Infrastructure.Identity;
using TFG.RulesPenaltiesF1.Web.Interfaces;
using TFG.RulesPenaltiesF1.Web.ViewModels;

namespace TFG.RulesPenaltiesF1.Web.Controllers;

public class IncidentsController : Controller
{
	private readonly UserManager<ApplicationUser> _userManager;
	private readonly ICompetitionViewModelService _competitionViewModelService;
	private readonly IRegulationViewModelService _regulationViewModelService;

	private readonly ICompetitionService _competitionService;

	public IncidentsController(UserManager<ApplicationUser> userManager, ICompetitionViewModelService competitionViewModelService,
		IRegulationViewModelService regulationViewModelService,
		ICompetitionService competitionService)
	{
		_userManager = userManager;
		_competitionViewModelService = competitionViewModelService;
		_regulationViewModelService = regulationViewModelService;
		_competitionService = competitionService;
	}

	[HttpGet]
	[Authorize(Roles = "Steward")]
	public async Task<IActionResult> Create(int? id)
	{
		if (id is null)
		{
			return NotFound();
		}

		var currentUser = await _userManager.GetUserAsync(HttpContext.User);

		if (currentUser is null)
		{
			return NotFound();
		}

		int sessionId = (int)id;

		if (!await _competitionViewModelService.CanAddIncident(sessionId))
		{
			return NotFound();
		}

		var competition = await _competitionViewModelService.GetBySessionId(sessionId);

		if (competition is null)
		{
			return NotFound();
		}

		IncidentViewModel incident = new()
		{
			CompetitionId = competition.Id,
			SessionId = (int)id,
			Session = competition.Sessions.Where(s => s.SessionId == sessionId).FirstOrDefault()
		};

		ViewBag.Competition = competition;
		ViewBag.Participations = competition.Participations.AsEnumerable();

		RegulationViewModel? regulation = await _regulationViewModelService.GetRegulationByCompetitionId(competition.Id);

		if(regulation is null)
		{
			return NotFound();
		}

		ViewBag.Articles = regulation.ArticlesContent;
		ViewBag.Penalties = regulation.PenaltiesContent;

		return View(incident);
	}

	[HttpPost]
	[Authorize(Roles = "Steward")]
	public async Task<IActionResult> Create(IncidentViewModel incident)
	{
		if (ModelState.IsValid)
		{
			var currentUser = await _userManager.GetUserAsync(HttpContext.User);

			if (currentUser is null)
			{
				return NotFound();
			}

			if (!await _competitionViewModelService.CanAddIncident(incident.SessionId))
			{
				return NotFound();
			}

			await _competitionService.AddIncident(IncidentViewModel.MapViewModelToEntity(incident));

			return RedirectToAction("Details", "Competitions", new { id = incident.CompetitionId });
		}

		return await Create(incident);
	}
}
