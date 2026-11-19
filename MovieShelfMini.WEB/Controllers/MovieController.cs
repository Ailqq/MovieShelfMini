using Microsoft.AspNetCore.Mvc;
using MovieShelfMini.Services.Contracts;

namespace MovieShelfMini.WEB.Controllers
{
    public class MovieController:Controller
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public async Task<IActionResult> Index()
        {
            var movies = await _movieService.GetAll();
            return View(movies);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string title, string director, string genre, int year, int duration)
        {
            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(director))
            {
                return View();
            }

            await _movieService.Create(title, director, genre, year, duration);
            return RedirectToAction(nameof(Index));
        }
    }
}
