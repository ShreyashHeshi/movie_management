namespace Movie.API.Models
{
    public class Director
    {
        public string Id { get; set; } // Primary Key
        public string Name { get; set; }
        public string Bio { get; set; }

        public ICollection<Movies> Movies { get; set; }
    }
}
