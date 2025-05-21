using System.ComponentModel.DataAnnotations;

namespace Movie.API.DTOs.Director
{
    public class DirectorCreateDto
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters")]
        public string Name { get; set; }

        [StringLength(1000, ErrorMessage = "Bio cannot be longer than 1000 characters")]
        public string Bio { get; set; }
        public string Nationality { get; set; }
    }
}
