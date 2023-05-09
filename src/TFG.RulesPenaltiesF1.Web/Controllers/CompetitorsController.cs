using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TFG.RulesPenaltiesF1.Core.Interfaces.Services;
using TFG.RulesPenaltiesF1.Web.Interfaces;
using TFG.RulesPenaltiesF1.Web.ViewModels;

namespace TFG.RulesPenaltiesF1.Web.Controllers
{
	public class CompetitorsController : Controller
   {
      private readonly ICompetitorViewModelService _viewModelService;
      private readonly ICompetitorService _service;

      public CompetitorsController(ICompetitorViewModelService viewModelService, ICompetitorService service)
      {
         _viewModelService = viewModelService;
         _service = service;
      }

      // GET: Competitors
      public async Task<IActionResult> Index()
      {
         var competitors = await _viewModelService.GetAllCompetitors();
         return View(competitors);
      }

      // GET: Competitors/Details/5
      public async Task<IActionResult> Details(int? id)
      {
         if (id == null)
         {
               return NotFound();
         }

         var competitor = await _viewModelService.GetByIdAsync((int)id);

         if (competitor == null)
         {
               return NotFound();
         }

         return View(competitor);
      }

      // GET: Competitors/Create
      [Authorize(Roles ="Steward")]
      public async Task<IActionResult> Create()
      {
         ViewData["TeamPrincipalID"] = new SelectList(await _viewModelService.GetAllTeamPrincipals(), "Id", "FullName");
         return View();
      }

      // POST: Competitors/Create
      // To protect from overposting attacks, enable the specific properties you want to bind to.
      // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
      [HttpPost]
      [ValidateAntiForgeryToken]
      [Authorize(Roles ="Steward")]
      public async Task<IActionResult> Create([Bind("Name,Location,TeamPrincipalId,PowerUnit,Id")] CompetitorViewModel competitor)
      {
         if (ModelState.IsValid)
         {
               bool exists = await _viewModelService.ExistsCompetitorWithName(competitor.Name);

            if (exists)
            {
                  ModelState.AddModelError("Name", "A regulation with name '" + competitor.Name + "' already exists");
                  ViewData["TeamPrincipalID"] = new SelectList(await _viewModelService.GetAllTeamPrincipals(), "Id", "FullName");
                  return View(competitor);
            }

               var competitorEntity = CompetitorViewModel.MapViewModelToEntity(competitor);
               if(competitorEntity is not null)
               {
                  await _service.CreateCompetitorAsync(competitorEntity);
                  return RedirectToAction(nameof(Index));
               }
         }
         ViewData["TeamPrincipalID"] = new SelectList(await _viewModelService.GetAllTeamPrincipals(), "Id", "FullName");
         return View(competitor);
      }
   }
}
