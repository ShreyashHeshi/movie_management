using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.IO;

namespace Movie.API.Models
{
    public class Movies
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } // Primary Key
        public string Title { get; set; }
        public string Description { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string DirectorId { get; set; } // Foreign Key to Director
        public DateTime ReleaseDate { get; set; }
        public double Rating { get; set; }

        [BsonIgnore] //we ignore this cause To avoid circular references and bloated data in the DB
        public Director Director { get; set; } // Navigation Property (optional)

        // if we not used navigation properties then Manual joining needed for related data
    }
}
