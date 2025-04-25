namespace Movie.API.Models
{
    public class MongoDBSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public CollectionNames CollectionNames { get; set; }

    }
    public class CollectionNames
    {
        public string Movies { get; set; }
        public string Directors { get; set; }
    }
}
