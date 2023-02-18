using System.Diagnostics;
using TFG.RulesPenaltiesF1.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace TFG.RulesPenaltiesF1.Web.Controllers
{

   public class HomeController : Controller
   {
      public IActionResult Index()
      {
         return View();
      }

      public int pepe()
      {
         return 5;
      }
   }
}
