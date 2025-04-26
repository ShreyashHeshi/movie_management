using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie.API.DTOs.Director;
using Movie.API.Models;
using Movie.API.Services;

namespace Movie.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorsController : ControllerBase
    {
        private readonly IDirectorService _directorService;

        public DirectorsController(IDirectorService directorService)
        {
            _directorService = directorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DirectorResponseDto>>> GetAll()
        {
            var directors = await _directorService.GetAllDirectors();
            return Ok(directors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DirectorResponseDto>> GetById(string id)
        {
            var director = await _directorService.GetDirectorById(id);
            if (director == null)
                return NotFound();

            return Ok(director);
        }

        [HttpPost]
        public async Task<ActionResult<DirectorResponseDto>> Create([FromBody] DirectorCreateDto directorCreateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdDirector = await _directorService.CreateDirector(directorCreateDto);
            return CreatedAtAction(nameof(GetById), new { id = createdDirector.Id }, createdDirector);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] DirectorUpdateDto directorUpdateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _directorService.UpdateDirector(id, directorUpdateDto);
            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _directorService.DeleteDirector(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
