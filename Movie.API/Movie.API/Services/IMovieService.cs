using Movie.API.DTOs.Movie;
using Movie.API.Models;

namespace Movie.API.Services
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieResponseDto>> GetAllMovies();
        Task<MovieResponseDto> GetMovieById(string id);
        Task<IEnumerable<MovieResponseDto>> GetMoviesByDirector(string directorId);
        Task<MovieResponseDto> CreateMovie(MovieCreateDto movieCreateDto);
        Task<bool> UpdateMovie(string id, MovieUpdateDto movieUpdateDto);
        Task<bool> DeleteMovie(string id);
    }
}
