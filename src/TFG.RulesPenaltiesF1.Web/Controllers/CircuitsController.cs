using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TFG.RulesPenaltiesF1.Core.Entities;
using TFG.RulesPenaltiesF1.Core.Interfaces.Services;
using TFG.RulesPenaltiesF1.Web.Interfaces;
using TFG.RulesPenaltiesF1.Web.ViewModels;

namespace TFG.RulesPenaltiesF1.Web.Controllers
{
   public class CircuitsController : Controller
    {
        private readonly ICircuitService _service;
        private readonly ICircuitViewModelService _viewModelService;

        public CircuitsController(ICircuitService service, ICircuitViewModelService viewModelService)
        {
            _service = service;
            _viewModelService = viewModelService;
        }

        // GET: Circuits
        public async Task<IActionResult> Index()
        {
            var circuits = await _viewModelService.GetAllCircuits();
            return View(circuits);
        }

        // GET: Circuits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var circuit =await _viewModelService.GetByIdAsync((int)id);

            if (circuit == null)
            {
                return NotFound();
            }

            return View(circuit);
        }

        // GET: Circuits/Create
        public async Task<IActionResult> Create()
        {
            ViewData["CountryId"] = new SelectList(await _viewModelService.GetAllCountries(), "Id", "Name");
            return View();
        }

        // POST: Circuits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CountryId,Name,Length,Laps,YearFirstGP,MillisecondsLapRecord,DriverLapRecord,YearLapRecord,Id")] CircuitViewModel circuit)
        {
            if (ModelState.IsValid)
            {
                var circuitEntity = _viewModelService.MapViewModelToEntity(circuit!);
                if(circuitEntity is not null)
                {
                     await _service.CreateCircuitAsync(circuitEntity!);
                     return RedirectToAction(nameof(Index));
                }
            }
            ViewData["CountryId"] = new SelectList(await _viewModelService.GetAllCountries(), "Id", "Name", circuit.CountryId);
            return View(new CircuitViewModel());
        }

        /*// GET: Circuits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Circuit == null)
            {
                return NotFound();
            }

            var circuit = await _context.Circuit.FindAsync(id);
            if (circuit == null)
            {
                return NotFound();
            }
            ViewData["CountryId"] = new SelectList(_context.Set<Country>(), "Id", "Name", circuit.CountryId);
            return View(circuit);
        }

        // POST: Circuits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CountryId,Name,Length,Laps,YearFirstGP,MillisecondsLapRecord,DriverLapRecord,YearLapRecord,Id")] Circuit circuit)
        {
            if (id != circuit.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(circuit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CircuitExists(circuit.Id))
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
            ViewData["CountryId"] = new SelectList(_context.Set<Country>(), "Id", "Name", circuit.CountryId);
            return View(circuit);
        }

        // GET: Circuits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Circuit == null)
            {
                return NotFound();
            }

            var circuit = await _context.Circuit
                .Include(c => c.Country)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (circuit == null)
            {
                return NotFound();
            }

            return View(circuit);
        }

        // POST: Circuits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Circuit == null)
            {
                return Problem("Entity set 'RulesPenaltiesF1DbContext.Circuit'  is null.");
            }
            var circuit = await _context.Circuit.FindAsync(id);
            if (circuit != null)
            {
                _context.Circuit.Remove(circuit);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CircuitExists(int id)
        {
          return (_context.Circuit?.Any(e => e.Id == id)).GetValueOrDefault();
        }*/
    }
}
