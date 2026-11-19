using MovieShelfMini.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShelfMini.Data.Migrations
{
    public class DemoData
    {
        public static void Seed(MovieDbContext db)
        {
            const string demoTitle = "Време разделно";

            if (db.Movies.Any(m => m.Title == demoTitle))
            {
                return;
            }

            var director = db.Directors.FirstOrDefault(d => d.Name == "Людмил Стайков");

            if (director is null)
            {
                director = new Director
                {
                    DirectorId = Guid.NewGuid(),
                    Name = "Людмил Стайков"
                };
                db.Directors.Add(director);
            }

            var movie = new Movie
            {
                MovieId = Guid.NewGuid(),
                Title = demoTitle,
                Genre = "Драма",
                Year = 1988,
                Duration = 285,
                DirectorId = director.DirectorId,
                Director = director
            };

            db.Movies.Add(movie);
            db.SaveChanges();
        }
    }
}
