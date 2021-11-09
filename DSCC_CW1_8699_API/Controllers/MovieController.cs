using DSCC_CW1_8699_API.Models;
using DSCC_CW1_8699_API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace DSCC_CW1_8699_API.Controllers
{
        [Produces("application/json")]
        [Route("api/Movie")]
        public class MovieController : Controller
        {
            private readonly IMovieRepository _movieRepository;
            public MovieController(IMovieRepository movieRepository)
            {
                _movieRepository = movieRepository;
            }
            // GET: api/Movie
            [HttpGet]
            public IActionResult Get()
            {
                var movies = _movieRepository.GetMovies();
                return new OkObjectResult(movies);
            }
        // GET: api/Movie/5
        [HttpGet("{id}", Name = "Get")]
            public IActionResult Get(int id)
            {
                var movie = _movieRepository.GetMovieById(id);
                return new OkObjectResult(movie);
            }
            // POST: api/Movie
            [HttpPost]
            public IActionResult Post([FromBody]Movie movie)
            {
                using (var scope = new TransactionScope())
                {
                    _movieRepository.AddMovie(movie);
                    scope.Complete();
                    return CreatedAtAction(nameof(Get), new { id = movie.Id }, movie);
                }
            }
            // PUT: api/Movie/5
            [HttpPut("{id}")]
            public IActionResult Put(int id, [FromBody]Movie movie)
            {
                if (movie != null)
                {
                    using (var scope = new TransactionScope())
                    {
                        _movieRepository.UpdateMovie(movie);
                        scope.Complete();
                        return new OkResult();
                    }
                }
                return new NoContentResult();
            }
            // DELETE: api/ApiWithActions/5
            [HttpDelete("{id}")]
            public IActionResult Delete(int id)
            {
                _movieRepository.DeleteMovie(id);
                return new OkResult();
            }
    }
}
