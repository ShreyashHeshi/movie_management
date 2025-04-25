using System.IO;

namespace Movie.API.Models
{
    public class Movies
    {
        public string Id { get; set; } // Primary Key
        public string Title { get; set; }
        public string Description { get; set; }
        public string DirectorId { get; set; } // Foreign Key to Director
        public DateTime ReleaseDate { get; set; }
        public double Rating { get; set; }

        public Director Director { get; set; } // Navigation Property (optional)
    }
}
