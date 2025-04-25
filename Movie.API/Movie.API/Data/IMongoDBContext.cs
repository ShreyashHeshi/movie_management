using MongoDB.Driver;
using Movie.API.Models;

namespace Movie.API.Data
{
    public interface IMongoDBContext
    {
        IMongoCollection<Movies> Movies { get; }
        IMongoCollection<Director> Directors { get; }
    }
}
