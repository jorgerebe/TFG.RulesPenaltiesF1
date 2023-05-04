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

               var competitorEntity = _viewModelService.MapViewModelToEntity(competitor);
               if(competitorEntity is not null)
               {
                  await _service.CreateCompetitorAsync(competitorEntity);
                  return RedirectToAction(nameof(Index));
               }
         }
         ViewData["TeamPrincipalID"] = new SelectList(await _viewModelService.GetAllTeamPrincipals(), "Id", "FullName");
         return View(competitor);
      }

      /*// GET: Competitors/Edit/5
      public async Task<IActionResult> Edit(int? id)
      {
         if (id == null || _context.Competitor == null)
         {
               return NotFound();
         }

         var competitor = await _context.Competitor.FindAsync(id);
         if (competitor == null)
         {
               return NotFound();
         }
         ViewData["TeamPrincipalID"] = new SelectList(_context.Users, "Id", "Id", competitor.TeamPrincipalID);
         return View(competitor);
      }

      // POST: Competitors/Edit/5
      // To protect from overposting attacks, enable the specific properties you want to bind to.
      // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
      [HttpPost]
      [ValidateAntiForgeryToken]
      public async Task<IActionResult> Edit(int id, [Bind("Name,Location,TeamPrincipalID,PowerUnit,Id")] Competitor competitor)
      {
         if (id != competitor.Id)
         {
               return NotFound();
         }

         if (ModelState.IsValid)
         {
               try
               {
                  _context.Update(competitor);
                  await _context.SaveChangesAsync();
               }
               catch (DbUpdateConcurrencyException)
               {
                  if (!CompetitorExists(competitor.Id))
                  {
                     return NotFound();
                  }
                  else
                  {
                     throw;
                  }
               }
               return RedirectToAction(nameof(Index));
         }
         ViewData["TeamPrincipalID"] = new SelectList(_context.Users, "Id", "Id", competitor.TeamPrincipalID);
         return View(competitor);
      }

      // GET: Competitors/Delete/5
      public async Task<IActionResult> Delete(int? id)
      {
         if (id == null || _context.Competitor == null)
         {
               return NotFound();
         }

         var competitor = await _context.Competitor
               .Include(c => c.TeamPrincipal)
               .FirstOrDefaultAsync(m => m.Id == id);
         if (competitor == null)
         {
               return NotFound();
         }

         return View(competitor);
      }

      // POST: Competitors/Delete/5
      [HttpPost, ActionName("Delete")]
      [ValidateAntiForgeryToken]
      public async Task<IActionResult> DeleteConfirmed(int id)
      {
         if (_context.Competitor == null)
         {
               return Problem("Entity set 'RulesPenaltiesF1DbContext.Competitor'  is null.");
         }
         var competitor = await _context.Competitor.FindAsync(id);
         if (competitor != null)
         {
               _context.Competitor.Remove(competitor);
         }
            
         await _context.SaveChangesAsync();
         return RedirectToAction(nameof(Index));
      }

      private bool CompetitorExists(int id)
      {
         return (_context.Competitor?.Any(e => e.Id == id)).GetValueOrDefault();
      }*/
   }
}
