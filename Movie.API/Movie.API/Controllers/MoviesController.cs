using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie.API.DTOs.Movie;
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

        //[Authorize(Roles = "User")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieResponseDto>>> GetAll()
        {
            var movies = await _movieService.GetAllMovies();
            return Ok(movies);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MovieResponseDto>> GetById(string id)
        {
            var movie = await _movieService.GetMovieById(id);
            if (movie == null)
                return NotFound();

            return Ok(movie);
        }

        [HttpGet("director/{directorId}")]
        public async Task<ActionResult<IEnumerable<MovieResponseDto>>> GetByDirector(string directorId)
        {
            var movies = await _movieService.GetMoviesByDirector(directorId);
            return Ok(movies);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<MovieResponseDto>> Create([FromBody] MovieCreateDto movieCreateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdMovie = await _movieService.CreateMovie(movieCreateDto);
            return CreatedAtAction(nameof(GetById), new { id = createdMovie.Id }, createdMovie);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] MovieUpdateDto movieUpdateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _movieService.UpdateMovie(id, movieUpdateDto);
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
