using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TFG.RulesPenaltiesF1.Core.Entities;
using TFG.RulesPenaltiesF1.Infrastructure.Data;

namespace TFG.RulesPenaltiesF1.Web.Controllers
{
    public class CompetitorsController : Controller
    {
        private readonly RulesPenaltiesF1DbContext _context;

        public CompetitorsController(RulesPenaltiesF1DbContext context)
        {
            _context = context;
        }

        // GET: Competitors
        public async Task<IActionResult> Index()
        {
            var rulesPenaltiesF1DbContext = _context.Competitor.Include(c => c.TeamPrincipal);
            return View(await rulesPenaltiesF1DbContext.ToListAsync());
        }

        // GET: Competitors/Details/5
        public async Task<IActionResult> Details(int? id)
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

        // GET: Competitors/Create
        public IActionResult Create()
        {
            ViewData["TeamPrincipalID"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Competitors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Location,TeamPrincipalID,PowerUnit,Id")] Competitor competitor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(competitor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TeamPrincipalID"] = new SelectList(_context.Users, "Id", "Id", competitor.TeamPrincipalID);
            return View(competitor);
        }

        // GET: Competitors/Edit/5
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
        }
    }
}
