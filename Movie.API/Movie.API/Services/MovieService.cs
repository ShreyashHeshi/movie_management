using Movie.API.Models;
using Movie.API.Repositories;

namespace Movie.API.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
        public async Task<Movies> CreateMovie(Movies movie)
        {
            return await _movieRepository.CreateMovie(movie);
        }

        public async Task<bool> DeleteMovie(string id)
        {
            return await _movieRepository.DeleteMovie(id);
        }

        public async Task<IEnumerable<Movies>> GetAllMovies()
        {
            return await _movieRepository.GetAllMovies();
        }

        public async Task<Movies> GetMovieById(string id)
        {
            return await _movieRepository.GetMovieById(id);
        }

        public async Task<IEnumerable<Movies>> GetMoviesByDirector(string directorId)
        {
            return await _movieRepository.GetMoviesByDirector(directorId);
        }

        public async Task<bool> UpdateMovie(string id, Movies movie)
        {
            return await _movieRepository.UpdateMovie(id, movie);
        }
    }
}
