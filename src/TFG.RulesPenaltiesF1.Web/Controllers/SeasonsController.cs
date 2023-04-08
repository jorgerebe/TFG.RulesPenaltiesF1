using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TFG.RulesPenaltiesF1.Core.Entities;
using TFG.RulesPenaltiesF1.Infrastructure.Data;

namespace TFG.RulesPenaltiesF1.Web.Controllers
{
   public class SeasonsController : Controller
    {
        private readonly RulesPenaltiesF1DbContext _context;

        public SeasonsController(RulesPenaltiesF1DbContext context)
        {
            _context = context;
        }

        // GET: Seasons
        public async Task<IActionResult> Index()
        {
            var rulesPenaltiesF1DbContext = _context.Season.Include(s => s.Regulation);
            return View(await rulesPenaltiesF1DbContext.ToListAsync());
        }

        // GET: Seasons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Season == null)
            {
                return NotFound();
            }

            var season = await _context.Season
                .Include(s => s.Regulation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (season == null)
            {
                return NotFound();
            }

            return View(season);
        }

        // GET: Seasons/Create
        public IActionResult Create()
        {
            ViewData["RegulationId"] = new SelectList(_context.Regulation, "Id", "Name");
            return View();
        }

        // POST: Seasons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Year,RegulationId,Id")] Season season)
        {
            if (ModelState.IsValid)
            {
                _context.Add(season);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RegulationId"] = new SelectList(_context.Regulation, "Id", "Name", season.RegulationId);
            return View(season);
        }

        // GET: Seasons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Season == null)
            {
                return NotFound();
            }

            var season = await _context.Season.FindAsync(id);
            if (season == null)
            {
                return NotFound();
            }
            ViewData["RegulationId"] = new SelectList(_context.Regulation, "Id", "Name", season.RegulationId);
            return View(season);
        }

        // POST: Seasons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Year,RegulationId,Id")] Season season)
        {
            if (id != season.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(season);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SeasonExists(season.Id))
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
            ViewData["RegulationId"] = new SelectList(_context.Regulation, "Id", "Name", season.RegulationId);
            return View(season);
        }

        // GET: Seasons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Season == null)
            {
                return NotFound();
            }

            var season = await _context.Season
                .Include(s => s.Regulation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (season == null)
            {
                return NotFound();
            }

            return View(season);
        }

        // POST: Seasons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Season == null)
            {
                return Problem("Entity set 'RulesPenaltiesF1DbContext.Season'  is null.");
            }
            var season = await _context.Season.FindAsync(id);
            if (season != null)
            {
                _context.Season.Remove(season);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SeasonExists(int id)
        {
          return (_context.Season?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
