using Hangfire.UI.HangfireJobs;
using Hangfire.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Hangfire.UI.Controllers
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
            //Job olaylarını tetikledik..
            FireAndForgetJobs.SimpleJobFireAndForget();
            DelayedJobs.SimpleDelayedJob();
            RecurringJobs.Recurring();
            ContinuationsJobs.Continuations();

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