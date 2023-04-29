using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TFG.RulesPenaltiesF1.Core.Entities;
using TFG.RulesPenaltiesF1.Core.Interfaces.Services;
using TFG.RulesPenaltiesF1.Web.Interfaces;
using TFG.RulesPenaltiesF1.Web.ViewModels;

namespace TFG.RulesPenaltiesF1.Web.Controllers
	{
	public class SeasonsController : Controller
	{
		private readonly ICircuitViewModelService _circuitViewModelService;

		private readonly ISeasonViewModelService _seasonViewModelService;
		private readonly ISeasonService _seasonService;

		private readonly IRegulationViewModelService _regulationViewModelService;
		private readonly ICompetitorViewModelService _competitorViewModelService;

		public SeasonsController(ICircuitViewModelService circuitViewModelService, ISeasonViewModelService seasonViewModelService,
			ISeasonService seasonService,
			IRegulationViewModelService regulationViewModelService, ICompetitorViewModelService competitorViewModelService)
		{
			_circuitViewModelService = circuitViewModelService;
			_seasonViewModelService = seasonViewModelService;
			_seasonService = seasonService;
			_regulationViewModelService = regulationViewModelService;
			_competitorViewModelService = competitorViewModelService;
		}

		// GET: Seasons
		public async Task<IActionResult> Index()
		{
			return View(await _seasonViewModelService.GetSeasonsAsync());
		}

		// GET: Seasons/Details/5
		public async Task<IActionResult> Details(int id)
		{
			var season = await _seasonViewModelService.GetByIdAsync(id);

			if (season == null)
			{
				return NotFound();
			}

			return View(season);
		}

		// GET: Seasons/Create
		[Authorize(Roles ="Steward")]
		public async Task<IActionResult> Create()
		{
			if(await _seasonViewModelService.CanCreateAnotherSeason() is false)
			{
				return NotFound();
			}

			SeasonViewModel season = new SeasonViewModel();
			List<CompetitionViewModel> competitions = new()
			{
				new CompetitionViewModel(),
				new CompetitionViewModel()
			};

			season.Competitions = competitions;

			ViewData["RegulationId"] = new SelectList(await _regulationViewModelService.GetRegulationsAsync(), "Id", "Name");
			ViewData["Circuits"] = await _circuitViewModelService.GetAllCircuits();
			ViewData["Competitors"] = (await _competitorViewModelService.GetAllCompetitors());
			return View(season);
		}

		// POST: Seasons/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize(Roles ="Steward")]
		public async Task<IActionResult> Create([Bind("Year,Competitors,Competitions,RegulationId")] SeasonViewModel season)
		{
			if (await _seasonViewModelService.CanCreateAnotherSeason() is false)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				if (await _seasonViewModelService.ExistsSeasonInYear(season.Year))
				{
					ModelState.AddModelError("Year", "There is already a season in the specified year.");
					await PopulateListsArticlesAndPenalties();
					return View(season);
				}

				List<int> weeks = new();
				List<string> names = new();

				int n = 0;

				foreach (var competition in season.Competitions)
				{
					if (weeks.Contains(competition.Week))
					{
						ModelState.AddModelError($"Competitions[{n}].Week", "Two competitions can't happen in the same week.");
						await PopulateListsArticlesAndPenalties();
						return View(season);
					}
					if (names.Contains(competition.Name))
					{
						ModelState.AddModelError($"Competitions[{n}].Name", "Two competitions in the same season can't have the same name.");
						await PopulateListsArticlesAndPenalties();
						return View(season);
					}

					weeks.Add(competition.Week);
					names.Add(competition.Name);

					n++;
				}

				Season seasonEntity = _seasonViewModelService.MapViewModelToEntity(season)!;
				await _seasonService.CreateSeasonAsync(seasonEntity);
				return RedirectToAction(nameof(Index));
			}
			await PopulateListsArticlesAndPenalties();
			return View(season);
		}

		private async Task PopulateListsArticlesAndPenalties()
		{
			ViewData["RegulationId"] = new SelectList(await _regulationViewModelService.GetRegulationsAsync(), "Id", "Name");
			ViewData["Circuits"] = await _circuitViewModelService.GetAllCircuits();
			ViewData["Competitors"] = (await _competitorViewModelService.GetAllCompetitors());
		}
	}
}
