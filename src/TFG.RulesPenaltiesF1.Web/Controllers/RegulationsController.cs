﻿using Microsoft.AspNetCore.Mvc;
using TFG.RulesPenaltiesF1.Core.Interfaces.Services;
using TFG.RulesPenaltiesF1.Web.Interfaces;
using TFG.RulesPenaltiesF1.Web.ViewModels;

namespace TFG.RulesPenaltiesF1.Web.Controllers;

public class RegulationsController : Controller
{
   private readonly IRegulationViewModelService _regulationServiceViewModel;
   private readonly IArticleViewModelService _articleServiceViewModel;
   private readonly IPenaltyViewModelService _penaltyServiceViewModel;

   private readonly IRegulationService _regulationService;

   public RegulationsController(IRegulationViewModelService regulationServiceViewModel, IArticleViewModelService articleServiceViewModel,
      IPenaltyViewModelService penaltyServiceViewModel, IRegulationService regulationService)
   {
      _regulationServiceViewModel = regulationServiceViewModel;
      _articleServiceViewModel = articleServiceViewModel;
      _penaltyServiceViewModel = penaltyServiceViewModel;

      _regulationService = regulationService;
   }

   // GET: Regulations
   public async Task<IActionResult> Index()
   {
      return View(await _regulationServiceViewModel.GetRegulationsAsync());
   }

   // GET: Regulations/Details/5
   public async Task<IActionResult> Details(int? id)
   {
      if (id == null)
      {
         return NotFound();
      }

      var regulation = await _regulationServiceViewModel.GetRegulationByIdAsync((int)id);
      if (regulation == null)
      {
         return NotFound();
      }

      return View(regulation);
   }

   // GET: Regulations/Create
   public async Task<ActionResult> Create()
   {
      //var articles = await _articleServiceViewModel.GetArticlesAsync();
      ViewBag.Articles = (await _articleServiceViewModel.GetArticlesAsync()).AsEnumerable();
      ViewBag.Penalties = (await _penaltyServiceViewModel.GetPenaltiesAsync()).AsEnumerable();

      return View();
   }

   // POST: Regulations/Create
   // To protect from overposting attacks, enable the specific properties you want to bind to.
   // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
   [HttpPost]
   [ValidateAntiForgeryToken]
   public async Task<IActionResult> Create(RegulationViewModel regulation)
   {
      /*if (ModelState.IsValid)
      {
            _context.Add(regulation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
      }*/
      try
      {
         if (ModelState.IsValid)
         {

            var regulationEntity = _regulationServiceViewModel.MapViewModelToEntity(regulation);

            if (regulationEntity != null)
            {
               await _regulationService.CreateRegulationAsync(regulationEntity);
               return RedirectToAction(nameof(Index));
            }
         }
      }
      catch (Exception)
      {
         ModelState.AddModelError("", "Unable to save changes. " +
         "Try again, and if the problem persists " +
         "see your system administrator.");
      }
      return Create().Result;
   }

     /*// GET: Regulations/Edit/5
     public async Task<IActionResult> Edit(int? id)
     {
         if (id == null || _context.Regulation == null)
         {
             return NotFound();
         }

         var regulation = await _context.Regulation.FindAsync(id);
         if (regulation == null)
         {
             return NotFound();
         }
         return View(regulation);
     }

     // POST: Regulations/Edit/5
     // To protect from overposting attacks, enable the specific properties you want to bind to.
     // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
     [HttpPost]
     [ValidateAntiForgeryToken]
     public async Task<IActionResult> Edit(int id, [Bind("Year,Id")] Regulation regulation)
     {
         if (id != regulation.Id)
         {
             return NotFound();
         }

         if (ModelState.IsValid)
         {
             try
             {
                 _context.Update(regulation);
                 await _context.SaveChangesAsync();
             }
             catch (DbUpdateConcurrencyException)
             {
                 if (!RegulationExists(regulation.Id))
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
         return View(regulation);
     }

     // GET: Regulations/Delete/5
     public async Task<IActionResult> Delete(int? id)
     {
         if (id == null || _context.Regulation == null)
         {
             return NotFound();
         }

         var regulation = await _context.Regulation
             .FirstOrDefaultAsync(m => m.Id == id);
         if (regulation == null)
         {
             return NotFound();
         }

         return View(regulation);
     }

     // POST: Regulations/Delete/5
     [HttpPost, ActionName("Delete")]
     [ValidateAntiForgeryToken]
     public async Task<IActionResult> DeleteConfirmed(int id)
     {
         if (_context.Regulation == null)
         {
             return Problem("Entity set 'RulesPenaltiesF1DbContext.Regulation'  is null.");
         }
         var regulation = await _context.Regulation.FindAsync(id);
         if (regulation != null)
         {
             _context.Regulation.Remove(regulation);
         }
         
         await _context.SaveChangesAsync();
         return RedirectToAction(nameof(Index));
     }*/
 }
