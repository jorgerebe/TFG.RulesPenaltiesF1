using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TFG.RulesPenaltiesF1.Core.Interfaces.Services;
using TFG.RulesPenaltiesF1.Web.Interfaces;
using TFG.RulesPenaltiesF1.Web.ViewModels;

namespace TFG.RulesPenaltiesF1.Web.Controllers;

public class DriversController : Controller
{
	private readonly IDriverViewModelService _driverViewModelService;
	private readonly IDriverService _driverService;

   private readonly ICompetitorViewModelService _competitorService;

   public DriversController(IDriverViewModelService driverViewModelService, IDriverService driverService,
	ICompetitorViewModelService competitorService)
   {
	_driverViewModelService = driverViewModelService;
	_driverService = driverService;
	_competitorService = competitorService;
   }

      // GET: Drivers
      public async Task<IActionResult> Index()
      {
		var drivers = await _driverViewModelService.GetAllDrivers();
         return View(drivers);
      }

      // GET: Drivers/Details/5
      public async Task<IActionResult> Details(int? id)
      {
         if (id == null)
         {
               return NotFound();
         }

			var driver = await _driverViewModelService.GetDriverById((int)id);
            
         if (driver == null)
         {
               return NotFound();
         }

         return View(driver);
      }

      // GET: Drivers/Create
      public async Task<IActionResult> Create()
      {
			await PopulateCompetitors();
         return View();
      }

      // POST: Drivers/Create
      // To protect from overposting attacks, enable the specific properties you want to bind to.
      // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
      [HttpPost]
      [ValidateAntiForgeryToken]
      public async Task<IActionResult> Create([Bind("Name,DateBirth,LicensePoints,CompetitorId")] DriverViewModel driver)
      {
         if (ModelState.IsValid)
         {
				if(driver.DateBirth.CompareTo(DateOnly.FromDateTime(DateTime.Now.AddYears(-18))) > 0)
				{
					ModelState.AddModelError("DateBirth", "A driver must be over 18.");
					await PopulateCompetitors();
					return View(driver);
				}
				if(await _driverViewModelService.ExistsDriverByName(driver.Name))
				{
					ModelState.AddModelError("Name", "There is already a driver with that name.");
					await PopulateCompetitors();
					return View(driver);
				}

				await _driverService.CreateDriverAsync(_driverViewModelService.MapViewModelToEntity(driver)!);
				return RedirectToAction(nameof(Index));
         }
			await PopulateCompetitors();
         return View(driver);
      }

	// GET: Drivers/Edit/5
	/*public async Task<IActionResult> Edit(int? id)
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
	}*/

	// POST: Drivers/Edit/5
	// To protect from overposting attacks, enable the specific properties you want to bind to.
	// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
	/*[HttpPost]
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
	}*/

	private async Task PopulateCompetitors()
	{
		ViewData["CompetitorId"] = new SelectList(await _competitorService.GetAllCompetitorsWithTeamPrincipals(), "Id", "Name");
	}
}
