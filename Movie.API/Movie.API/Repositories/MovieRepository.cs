using MongoDB.Driver;
using Movie.API.Data;
using Movie.API.Models;

namespace Movie.API.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly IMongoDBContext _context;

        public MovieRepository(IMongoDBContext context)
        {
            _context = context;
        }
        public async Task<Movies> CreateMovie(Movies movie)
        {
            await _context.Movies.InsertOneAsync(movie);
            return movie;
        }

        public async Task<bool> DeleteMovie(string id)
        {
            var deleteResult = await _context.Movies.DeleteOneAsync(m => m.Id == id);
            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public async Task<IEnumerable<Movies>> GetAllMovies()
        {
            return await _context.Movies.Find(_ => true).ToListAsync();
        }

        public async Task<Movies> GetMovieById(string id)
        {
            return await _context.Movies.Find(m => m.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Movies>> GetMoviesByDirector(string directorId)
        {
            return await _context.Movies.Find(m => m.DirectorId == directorId).ToListAsync();
        }

        public async Task<bool> UpdateMovie(string id, Movies movie)
        {
            var updateResult = await _context.Movies.ReplaceOneAsync(m => m.Id == id, movie);
            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }
    }
}
