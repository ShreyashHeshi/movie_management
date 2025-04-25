using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie.API.Models;
using Movie.API.Services;

namespace Movie.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var movies = await _movieService.GetAllMovies();
            return Ok(movies);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var movie = await _movieService.GetMovieById(id);
            if (movie == null)
                return NotFound();

            return Ok(movie);
        }

        [HttpGet("director/{directorId}")]
        public async Task<IActionResult> GetByDirector(string directorId)
        {
            var movies = await _movieService.GetMoviesByDirector(directorId);
            return Ok(movies);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Movies movie)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdMovie = await _movieService.CreateMovie(movie);
            return CreatedAtAction(nameof(GetById), new { id = createdMovie.Id }, createdMovie);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] Movies movie)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _movieService.UpdateMovie(id, movie);
            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _movieService.DeleteMovie(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
