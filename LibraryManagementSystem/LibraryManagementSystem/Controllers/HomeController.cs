using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.ShowNavbar = true;
            return View();
        }

        public IActionResult About()
        {
            ViewBag.ShowNavbar = true;
            return View();
        }
    }
}
