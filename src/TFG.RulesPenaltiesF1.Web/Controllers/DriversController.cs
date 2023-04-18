﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TFG.RulesPenaltiesF1.Core.Entities;
using TFG.RulesPenaltiesF1.Infrastructure.Data;

namespace TFG.RulesPenaltiesF1.Web.Controllers
	{
	public class DriversController : Controller
    {
        private readonly RulesPenaltiesF1DbContext _context;

        public DriversController(RulesPenaltiesF1DbContext context)
        {
            _context = context;
        }

        // GET: Drivers
        public async Task<IActionResult> Index()
        {
            var rulesPenaltiesF1DbContext = _context.Driver.Include(d => d.Competitor);
            return View(await rulesPenaltiesF1DbContext.ToListAsync());
        }

        // GET: Drivers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Driver == null)
            {
                return NotFound();
            }

            var driver = await _context.Driver
                .Include(d => d.Competitor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (driver == null)
            {
                return NotFound();
            }

            return View(driver);
        }

        // GET: Drivers/Create
        public IActionResult Create()
        {
            ViewData["CompetitorId"] = new SelectList(_context.Competitor, "Id", "Name");
            return View();
        }

        // POST: Drivers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,DateBirth,LicensePoints,CompetitorId")] Driver driver)
        {
            if (ModelState.IsValid)
            {
                _context.Add(driver);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CompetitorId"] = new SelectList(_context.Competitor, "Id", "Name", driver.CompetitorId);
            return View(driver);
        }

        // GET: Drivers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Driver == null)
            {
                return NotFound();
            }

            var driver = await _context.Driver.FindAsync(id);
            if (driver == null)
            {
                return NotFound();
            }
            ViewData["CompetitorId"] = new SelectList(_context.Competitor, "Id", "Name", driver.CompetitorId);
            return View(driver);
        }

        // POST: Drivers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CompetitorId")] Driver driver)
        {
            if (id != driver.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(driver);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DriverExists(driver.Id))
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
            ViewData["CompetitorId"] = new SelectList(_context.Competitor, "Id", "Name", driver.CompetitorId);
            return View(driver);
        }

        // GET: Drivers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Driver == null)
            {
                return NotFound();
            }

            var driver = await _context.Driver
                .Include(d => d.Competitor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (driver == null)
            {
                return NotFound();
            }

            return View(driver);
        }

        // POST: Drivers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Driver == null)
            {
                return Problem("Entity set 'RulesPenaltiesF1DbContext.Driver'  is null.");
            }
            var driver = await _context.Driver.FindAsync(id);
            if (driver != null)
            {
                _context.Driver.Remove(driver);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DriverExists(int id)
        {
          return (_context.Driver?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
