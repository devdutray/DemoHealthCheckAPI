using DemoHealthcheckAPI.Models;
using DemoHealthcheckAPI.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoHealthcheckAPI.Controllers
{
    [ApiController]
    [Route("movie")]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        // GET movie/movies
        [HttpGet("/getAllMovies")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetAllMovies()
        {
            return Ok(await _movieService.GetAllMoviesAsync());
        }

        // GET movie/movies/5
        [HttpGet("/getMovies/{id}")]
        public async Task<ActionResult<Movie>> GetMovie(int id)
        {
            var movie = await _movieService.GetMovieByIdAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return movie;
        }

        // POST movie/movies
        [HttpPost]
        public async Task<ActionResult<Movie>> CreateMovie(Movie movie)
        {
            await _movieService.CreateMovieAsync(movie);
            return CreatedAtAction(nameof(GetMovie), new { id = movie.Id }, movie);
        }

        // PUT movie/movies/5
        [HttpPut("updateMovie/{id}")]
        public async Task<IActionResult> UpdateMovie(int id, Movie movie)
        {
            if (id != movie.Id)
            {
                return BadRequest();
            }
            await _movieService.UpdateMovieAsync(movie);
            return NoContent();
        }

        // DELETE movie/movies/5
        [HttpDelete("deleteMovie/{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            await _movieService.DeleteMovieAsync(id);
            return NoContent();
        }
    }
}
