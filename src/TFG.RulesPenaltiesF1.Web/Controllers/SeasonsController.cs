using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TFG.RulesPenaltiesF1.Core.Entities.RegulationAggregate;
using TFG.RulesPenaltiesF1.Web.Interfaces;
using TFG.RulesPenaltiesF1.Web.ViewModels;

namespace TFG.RulesPenaltiesF1.Web.Controllers
{
   public class SeasonsController : Controller
    {
        private readonly ICircuitViewModelService _circuitViewModelService;
        private readonly ISeasonViewModelService _seasonViewModelService;
        private readonly IRegulationViewModelService _regulationViewModelService;
        private readonly ICompetitorViewModelService _competitorViewModelService;

        public SeasonsController(ICircuitViewModelService circuitViewModelService, ISeasonViewModelService seasonViewModelService,
           IRegulationViewModelService regulationViewModelService, ICompetitorViewModelService competitorViewModelService)
        {
            _circuitViewModelService = circuitViewModelService;
            _seasonViewModelService = seasonViewModelService;
            _regulationViewModelService = regulationViewModelService;
            _competitorViewModelService = competitorViewModelService;
        }

        // GET: Seasons
        public IActionResult Index()
        {
            return View(new List<SeasonViewModel>());
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
        public async Task<IActionResult> Create()
        {
            SeasonViewModel season = new SeasonViewModel();
            List<CompetitionViewModel> competitions = new()
            {
               new CompetitionViewModel(),
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
        public async Task<IActionResult> Create(SeasonViewModel season)
        {
            if (ModelState.IsValid)
            {
                List<int> weeks = new();
                List<string> name = new();
					 int n = 0;
                foreach(var competition in season.Competitions)
                {
						if (weeks.Contains(competition.Week))
                  {
							ModelState.AddModelError("Week", "Two competitors can't happen in the same week'");
						}
						if (name.Contains(competition.Name))
                  {
							ModelState.AddModelError("Name", "Two competitions in the same season can't have the same name");
						}
						n++;
                }
                /*_context.Add(season);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));*/
            }
            ViewData["RegulationId"] = new SelectList(await _regulationViewModelService.GetRegulationsAsync(), "Id", "Name");
            ViewData["Circuits"] = new SelectList(await _circuitViewModelService.GetAllCircuits(), "Id", "Name");
            ViewBag.Competitors = (await _competitorViewModelService.GetAllCompetitors()).AsEnumerable();
            return View(season);
        }
   }
}
