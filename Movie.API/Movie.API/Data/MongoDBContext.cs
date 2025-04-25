using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Movie.API.Models;

namespace Movie.API.Data
{
    public class MongoDBContext : IMongoDBContext
    {
        private readonly IMongoDatabase _database;

        public MongoDBContext(IOptions<MongoDBSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            _database = client.GetDatabase(settings.Value.DatabaseName);
        }

        public IMongoCollection<Movies> Movies => _database.GetCollection<Movies>("Movies");

        public IMongoCollection<Director> Directors => _database.GetCollection<Director>("Directors");
    }
}
