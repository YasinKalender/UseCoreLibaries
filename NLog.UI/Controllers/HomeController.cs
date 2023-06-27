using Microsoft.AspNetCore.Mvc;
using NLog.UI.Models;
using System.Diagnostics;

namespace NLog.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILogger<HomeController> _nlogLogger;

        public HomeController(ILogger<HomeController> logger, ILogger<HomeController> nlogLogger)
        {
            _logger = logger;
            _nlogLogger = nlogLogger;
        }

        public IActionResult Index()
        {
            _nlogLogger.LogInformation("Nlog ile loglandı");
            throw new Exception();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}