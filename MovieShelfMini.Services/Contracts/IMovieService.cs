using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieShelfMini.Data.Entities;

namespace MovieShelfMini.Services.Contracts
{
    public interface IMovieService
    {
        Task<List<Movie>> GetAll();

        Task Create(string title, string director, string genre, int year, int duration);
    }
}
