using DSCC_CW1_8699_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSCC_CW1_8699_API.Repositories
{
    public interface IMovieRepository
    {
        void AddMovie(Movie movie);
        void UpdateMovie(Movie movie);
        void DeleteMovie(int movieId);
        Movie GetMovieById(int id);
        IEnumerable<Movie> GetMovies();
    }
}
