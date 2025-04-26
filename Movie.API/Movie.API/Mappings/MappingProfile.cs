using static System.Runtime.InteropServices.JavaScript.JSType;
using AutoMapper;
using Movie.API.DTOs.Movie;     // For Movie DTOs
using Movie.API.DTOs.Director;  // For Director DTOs
using Movie.API.Models;
namespace Movie.API.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Movie mappings
            CreateMap<MovieCreateDto, Movies>();
            CreateMap<MovieUpdateDto, Movies>();
            CreateMap<Movies, MovieResponseDto>();

            // Director mappings
            CreateMap<DirectorCreateDto, Director>();
            CreateMap<DirectorUpdateDto, Director>();
            CreateMap<Director, DirectorResponseDto>();
        }
    }
}
