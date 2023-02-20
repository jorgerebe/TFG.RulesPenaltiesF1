using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TFG.RulesPenaltiesF1.Core.Entities;
using TFG.RulesPenaltiesF1.Infrastructure.Data;
using TFG.RulesPenaltiesF1.Web.Interfaces;

namespace TFG.RulesPenaltiesF1.Web.Controllers
{
   public class ArticleController : Controller
   {
      private readonly IArticleViewModelService _service;

      public ArticleController(IArticleViewModelService service)
      {
         _service = service;
      }

      // GET: Article
      public async Task<IActionResult> Index()
      {
         return View(await _service.GetArticlesAsync());
         /*return _context.Articles != null ?
                     View(await _context.Articles.ToListAsync()) :
                     Problem("Entity set 'RulesPenaltiesF1DbContext.Articles'  is null.");*/
      }

      // GET: Article/Details/5
      public async Task<IActionResult> Details(int? id)
      {
         if (id == null)
         {
            return NotFound();
         }

         var article = await _service.GetByIdAsync(id.Value);

         if (article == null)
         {
            return NotFound();
         }

         return View(article);
      }

      // GET: Article/Create
      public IActionResult Create()
      {
         return View();
      }

      // POST: Article/Create
      // To protect from overposting attacks, enable the specific properties you want to bind to.
      // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
      /*[HttpPost]
      [ValidateAntiForgeryToken]
      public async Task<IActionResult> Create([Bind("Content,Id")] Article article)
      {
         if (ModelState.IsValid)
         {
            _context.Add(article);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
         }
         return View(article);
      }

      // GET: Article/Edit/5
      public async Task<IActionResult> Edit(int? id)
      {
         if (id == null || _context.Articles == null)
         {
            return NotFound();
         }

         var article = await _context.Articles.FindAsync(id);
         if (article == null)
         {
            return NotFound();
         }
         return View(article);
      }

      // POST: Article/Edit/5
      // To protect from overposting attacks, enable the specific properties you want to bind to.
      // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
      [HttpPost]
      [ValidateAntiForgeryToken]
      public async Task<IActionResult> Edit(int id, [Bind("Content,Id")] Article article)
      {
         if (id != article.Id)
         {
            return NotFound();
         }

         if (ModelState.IsValid)
         {
            try
            {
               _context.Update(article);
               await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
               if (!ArticleExists(article.Id))
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
         return View(article);
      }

      // GET: Article/Delete/5
      public async Task<IActionResult> Delete(int? id)
      {
         if (id == null || _context.Articles == null)
         {
            return NotFound();
         }

         var article = await _context.Articles
             .FirstOrDefaultAsync(m => m.Id == id);
         if (article == null)
         {
            return NotFound();
         }

         return View(article);
      }

      // POST: Article/Delete/5
      [HttpPost, ActionName("Delete")]
      [ValidateAntiForgeryToken]
      public async Task<IActionResult> DeleteConfirmed(int id)
      {
         if (_context.Articles == null)
         {
            return Problem("Entity set 'RulesPenaltiesF1DbContext.Articles'  is null.");
         }
         var article = await _context.Articles.FindAsync(id);
         if (article != null)
         {
            _context.Articles.Remove(article);
         }

         await _context.SaveChangesAsync();
         return RedirectToAction(nameof(Index));
      }

      private bool ArticleExists(int id)
      {
         return (_context.Articles?.Any(e => e.Id == id)).GetValueOrDefault();
      }*/
   }
}
