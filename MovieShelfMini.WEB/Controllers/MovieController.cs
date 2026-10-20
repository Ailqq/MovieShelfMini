using Microsoft.AspNetCore.Mvc;

namespace MovieShelfMini.WEB.Controllers
{
    public class MovieController:Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
