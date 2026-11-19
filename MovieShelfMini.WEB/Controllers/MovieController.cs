using Microsoft.AspNetCore.Mvc;
using MovieShelfMini.Services.Contracts;

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
