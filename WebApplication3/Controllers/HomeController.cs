using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ElectronicsStore.Models;

namespace ElectronicsStore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Company sells electronics items and equimpment.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Electronic Store Contact 555-555-5555.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
