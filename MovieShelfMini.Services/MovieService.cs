using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieShelfMini.Data;
using MovieShelfMini.Data.Entities;
using MovieShelfMini.Services.Contracts;


namespace MovieShelfMini.Services
{
    public class MovieService : IMovieService
    {
        private readonly MovieDbContext _db;

        public MovieService(MovieDbContext context)
        {
            _db = context;
        }

        public async Task Create(string title, string director, string genre, int year, int duration)
        {
            var existingDirector = await _db.Directors
                .FirstOrDefaultAsync(d => d.Name == director);

            if (existingDirector is null)
            {
                existingDirector = new Director
                {
                    DirectorId = Guid.NewGuid(),
                    Name = director
                };

                _db.Directors.Add(existingDirector);
            }

            var movie = new Movie
            {
                MovieId = Guid.NewGuid(),
                Title = title,
                Genre = genre,
                Year = year,
                Duration = duration,
                DirectorId = existingDirector.DirectorId,
                Director = existingDirector
            };

            _db.Movies.Add(movie);
            await _db.SaveChangesAsync();
        }

        public Task<List<Movie>> GetAll()
        {
            return _db.Movies
                .Include(m => m.Director)
                .OrderBy(m => m.Title)
                .ToListAsync();
        }
    }
}
