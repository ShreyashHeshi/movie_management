using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Movie.API.Models
{
    public class Director
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } // Primary Key
        public string Name { get; set; }
        public string Bio { get; set; }

        [BsonIgnoreIfNull]
        public string Nationality { get; set; }

        [BsonIgnore]
        public ICollection<Movies> Movies { get; set; }
    }
}
