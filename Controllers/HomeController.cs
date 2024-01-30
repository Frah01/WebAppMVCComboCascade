using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebAppMVCComboCascade.Models;

namespace WebAppMVCComboCascade.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(); //Index.cshtml    che si trova in Views/Home/Index.cshtml
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier }); //Error.cshtml si trova in Views/Shared/Error.cshtml Si trova in shared perchè l'errore è comune e condiviso
        }
    }
}
