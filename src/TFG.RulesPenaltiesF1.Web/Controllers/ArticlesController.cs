using Microsoft.AspNetCore.Mvc;
using TFG.RulesPenaltiesF1.Core.Interfaces.Services;
using TFG.RulesPenaltiesF1.Web.Interfaces;
using TFG.RulesPenaltiesF1.Web.ViewModels;

namespace TFG.RulesPenaltiesF1.Web.Controllers
{
   public class ArticlesController : Controller
   {
      private readonly IArticleViewModelService _serviceViewModel;
      private readonly IArticleService _service;

      public ArticlesController(IArticleViewModelService serviceViewModel, IArticleService service)
      {
         _serviceViewModel = serviceViewModel;
         _service = service;
      }

      // GET: Articles
      public async Task<IActionResult> Index()
      {
         return View(await _serviceViewModel.GetArticlesAsync());
      }

      // GET: Articles/Details/5
      public async Task<IActionResult> Details(int? id)
      {
         if (id == null)
         {
            return NotFound();
         }

         var article = await _serviceViewModel.GetByIdAsync(id.Value);

         if (article == null)
         {
            return NotFound();
         }

         return View(article);
      }

      // GET: Articles/Create
      public IActionResult Create()
      {
         return View();
      }

      //POST: Articles/Create
      // To protect from overposting attacks, enable the specific properties you want to bind to.
      // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
      [HttpPost]
      [ValidateAntiForgeryToken]
      public async Task<IActionResult> Create(ArticleViewModel article)
      {
         try
         {
            if(ModelState.IsValid)
            {

               var articleEntity = _serviceViewModel.MapViewModelToEntity(article);

               if(articleEntity != null)
               {
                  await _service.CreateArticleAsync(articleEntity);
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

         return View(article);
      }

      // GET: Article/Edit/5
      /*public async Task<IActionResult> Edit(int? id)
      {
         if (id == null)
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
      }*/
   }
}
