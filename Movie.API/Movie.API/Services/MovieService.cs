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
        private readonly IRedisCacheService _cacheService;

        public MovieService(IMovieRepository movieRepository, IMapper mapper, IRedisCacheService cacheService)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
            _cacheService = cacheService;
        }

        public async Task<MovieResponseDto> CreateMovie(MovieCreateDto movieCreateDto)
        {
            var movie = _mapper.Map<Movies>(movieCreateDto);
            await _movieRepository.CreateMovie(movie);

            // After creating a new movie, refresh the cache
            var allMovies = await _movieRepository.GetAllMovies();
            var mappedMovies = _mapper.Map<IEnumerable<MovieResponseDto>>(allMovies);
            await _cacheService.SetAsync("movies:all", mappedMovies, TimeSpan.FromMinutes(60));

            return _mapper.Map<MovieResponseDto>(movie);
        }

        public async Task<bool> DeleteMovie(string id)
        {
            //return await _movieRepository.DeleteMovie(id);
            var deletedMovie= await _movieRepository.DeleteMovie(id);
            if (deletedMovie)
            {
                // Invalidate the cached movie list
                await _cacheService.RemoveAsync("movies:all");
            }
            return deletedMovie;
        }

        public async Task<IEnumerable<MovieResponseDto>> GetAllMovies()
        {
            const string cacheKey = "movies:all";

            // Try to get from cache
            var cachedMovies = await _cacheService.GetAsync<IEnumerable<MovieResponseDto>>(cacheKey);
            if (cachedMovies != null)
            {
                Console.WriteLine("✅ Retrieved movies from Redis cache");
                return cachedMovies;
            }

            // If not found in cache, get from DB
            Console.WriteLine("📦 Retrieved movies from database");
            var movies = await _movieRepository.GetAllMovies();
            var mappedMovies = _mapper.Map<IEnumerable<MovieResponseDto>>(movies);

            // Cache the result
            await _cacheService.SetAsync(cacheKey, mappedMovies, TimeSpan.FromMinutes(60));
            

            return mappedMovies;
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
            //return await _movieRepository.UpdateMovie(id, existingMovie);
            var updated = await _movieRepository.UpdateMovie(id, existingMovie);

            if (updated)
            {
                // Refresh the cached movie list
                var allMovies = await _movieRepository.GetAllMovies();
                var mappedMovies = _mapper.Map<IEnumerable<MovieResponseDto>>(allMovies);
                await _cacheService.SetAsync("movies:all", mappedMovies, TimeSpan.FromMinutes(60));
            }

            return updated;
        }
    }
}
