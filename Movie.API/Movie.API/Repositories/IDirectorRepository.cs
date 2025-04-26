using Movie.API.Models;

namespace Movie.API.Repositories
{
    public interface IDirectorRepository
    {
        Task<IEnumerable<Director>> GetAllDirectors();
        Task<Director> GetDirectorById(string id);
        Task<Director> CreateDirector(Director director);
        Task<bool> UpdateDirector(string id, Director director);
        Task<bool> DeleteDirector(string id);
    }
}
