using DSCC_CW1_8699_API.DbContexts;
using DSCC_CW1_8699_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSCC_CW1_8699_API.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieContext _dbContext;
        public MovieRepository(MovieContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void DeleteMovie(int movieId)
        {
            var movie = _dbContext.Movies.Find(movieId);
            _dbContext.Movies.Remove(movie);
            Save();
        }
        public Movie GetMovieById(int movieId)
        {
            var mov = _dbContext.Movies.Find(movieId);
            return mov;
        }
        public IEnumerable<Movie> GetMovies()
        {
            return _dbContext.Movies.ToList();
        }
        public void AddMovie(Movie movie)
        {
            _dbContext.Add(movie);
            Save();
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }
        public void UpdateMovie(Movie movie)
        {
            _dbContext.Entry(movie).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Save();
        }
    }
}
