using MongoDB.Driver;
using Movie.API.Data;
using Movie.API.Models;

namespace Movie.API.Repositories
{
    public class DirectorRepository : IDirectorRepository
    {
        private readonly IMongoDBContext _context;

        public DirectorRepository(IMongoDBContext context)
        {
            _context = context;
        }
        public async Task<Director> CreateDirector(Director director)
        {
            await _context.Directors.InsertOneAsync(director);
            return director;
        }

        public async Task<bool> DeleteDirector(string id)
        {
            var deleteResult = await _context.Directors.DeleteOneAsync(d => d.Id == id);
            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public async Task<IEnumerable<Director>> GetAllDirectors()
        {
            return await _context.Directors.Find(_ => true).ToListAsync();
        }

        public async Task<Director> GetDirectorById(string id)
        {
            return await _context.Directors.Find(d => d.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateDirector(string id, Director director)
        {
            var updateResult = await _context.Directors.ReplaceOneAsync(d => d.Id == id, director);
            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }
    }
}
