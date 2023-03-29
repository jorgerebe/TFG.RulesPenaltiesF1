using Microsoft.AspNetCore.Authorization;
using System.Data;
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
      [Authorize(Roles = "Steward")]
      public IActionResult Create()
      {
         return View();
      }

      //POST: Articles/Create
      // To protect from overposting attacks, enable the specific properties you want to bind to.
      // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
      [HttpPost]
      [ValidateAntiForgeryToken]
      [Authorize(Roles = "Steward")]
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
   }
}
