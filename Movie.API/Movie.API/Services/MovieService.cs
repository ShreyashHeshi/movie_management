using Movie.API.DTOs.Movie;
using Movie.API.Models;
using Movie.API.Repositories;
using AutoMapper;

namespace Movie.API.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;


        public MovieService(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public async Task<MovieResponseDto> CreateMovie(MovieCreateDto movieCreateDto)
        {
            var movie = _mapper.Map<Movies>(movieCreateDto);
            await _movieRepository.CreateMovie(movie);
            return _mapper.Map<MovieResponseDto>(movie);
        }

        public async Task<bool> DeleteMovie(string id)
        {
            return await _movieRepository.DeleteMovie(id);
        }

        public async Task<IEnumerable<MovieResponseDto>> GetAllMovies()
        {
            var movies = await _movieRepository.GetAllMovies();
            return _mapper.Map<IEnumerable<MovieResponseDto>>(movies);
        }

        public async Task<MovieResponseDto> GetMovieById(string id)
        {
            var movie = await _movieRepository.GetMovieById(id);
            return _mapper.Map<MovieResponseDto>(movie);
        }

        public async Task<IEnumerable<MovieResponseDto>> GetMoviesByDirector(string directorId)
        {
            var movies = await _movieRepository.GetMoviesByDirector(directorId);
            return _mapper.Map<IEnumerable<MovieResponseDto>>(movies);
        }

        public async Task<bool> UpdateMovie(string id, MovieUpdateDto movieUpdateDto)
        {
            var existingMovie = await _movieRepository.GetMovieById(id);
            if (existingMovie == null)
                return false;

            _mapper.Map(movieUpdateDto, existingMovie);
            return await _movieRepository.UpdateMovie(id, existingMovie);
        }
    }
}
