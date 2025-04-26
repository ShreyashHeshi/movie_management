

namespace Movie.API.DTOs.Movie
{
    public class MovieResponseDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string DirectorId { get; set; }
        public DateTime ReleaseDate { get; set; }
        public double Rating { get; set; }
        //public DirectorResponseDto Director { get; set; }
    }
}
