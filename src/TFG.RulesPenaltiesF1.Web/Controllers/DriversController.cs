using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TFG.RulesPenaltiesF1.Core.Interfaces;
using TFG.RulesPenaltiesF1.Core.Interfaces.Services;
using TFG.RulesPenaltiesF1.Web.Interfaces;
using TFG.RulesPenaltiesF1.Web.ViewModels;

namespace TFG.RulesPenaltiesF1.Web.Controllers;

public class DriversController : Controller
{
	private readonly IDriverViewModelService _driverViewModelService;
	private readonly IDriverService _driverService;

   private readonly ICompetitorViewModelService _competitorService;
	private readonly IDateTimeService _dateTimeService;

	public DriversController(IDriverViewModelService driverViewModelService, IDriverService driverService,
	ICompetitorViewModelService competitorService, IDateTimeService dateTimeService)
   {
		_driverViewModelService = driverViewModelService;
		_driverService = driverService;
		_competitorService = competitorService;
		_dateTimeService = dateTimeService;
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
	[Authorize(Roles = "Steward")]
	public async Task<IActionResult> Create()
   {
		await PopulateCompetitors(-1);
      return View();
   }

   // POST: Drivers/Create
   // To protect from overposting attacks, enable the specific properties you want to bind to.
   // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
   [HttpPost]
   [ValidateAntiForgeryToken]
	[Authorize(Roles = "Steward")]
	public async Task<IActionResult> Create([Bind("Name,DateBirth,LicensePoints,CompetitorId")] DriverViewModel driver)
   {
      if (ModelState.IsValid)
      {
			if(driver.Name.Replace("\t", " ").Replace(" ", "").Length < 5)
			{
				ModelState.AddModelError("Name", "The driver's name must have at least 5 chars length");
				await PopulateCompetitors(driver.CompetitorId);
				return View(driver);
			}
			if(driver.DateBirth.CompareTo(DateOnly.FromDateTime(_dateTimeService.Now().AddYears(-18))) > 0)
			{
				ModelState.AddModelError("DateBirth", "A driver must be over 18.");
				await PopulateCompetitors(driver.CompetitorId);
				return View(driver);
			}
			if(await _driverViewModelService.ExistsDriverByName(driver.Name))
			{
				ModelState.AddModelError("Name", "There is already a driver with that name.");
				await PopulateCompetitors(driver.CompetitorId);
				return View(driver);
			}

			await _driverService.CreateDriverAsync(DriverViewModel.MapViewModelToEntity(driver)!);
			return RedirectToAction(nameof(Index));
      }
		await PopulateCompetitors(driver.CompetitorId);
      return View(driver);
   }

	// GET: Drivers/Edit/5
	[Authorize(Roles = "Steward")]
	public async Task<IActionResult> Edit(int? id)
	{
		 if (id is null)
		 {
			  return NotFound();
		 }

		 var driver = await _driverViewModelService.GetDriverById((int)id);

		 if (driver == null)
		 {
			  return NotFound();
		 }

		 await PopulateCompetitors(driver.CompetitorId);
		 return View(driver);
	}

	// POST: Drivers/Edit/5
	// To protect from overposting attacks, enable the specific properties you want to bind to.
	// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
	[HttpPost]
	[ValidateAntiForgeryToken]
	[Authorize(Roles = "Steward")]
	public async Task<IActionResult> Edit(int id, DriverViewModel driver)
	{
		 if (id != driver.Id)
		 {
			  return NotFound();
		 }

		 var driverViewModel = await _driverViewModelService.GetDriverById(id);

		 if(driverViewModel is null)
		 {
				return NotFound();
		 }

		if (driver.CompetitorId == -1)
		{
			driverViewModel.Competitor = null;
			driverViewModel.CompetitorId = -1;
		}
		else if (await _competitorService.GetByIdAsync(driver.CompetitorId) is not null)
		{
			driverViewModel.CompetitorId = driver.CompetitorId;
		}
		else
		{
			return NotFound();
		}
		await _driverService.UpdateDriverAsync(DriverViewModel.MapViewModelToEntity(driverViewModel)!);

		return RedirectToAction(nameof(Index));
	}

	private async Task PopulateCompetitors(int competitorId)
	{
		ViewData["CompetitorId"] = new SelectList(await _competitorService.GetAllCompetitorsWithTeamPrincipals(), "Id", "Name", competitorId);
	}
}
