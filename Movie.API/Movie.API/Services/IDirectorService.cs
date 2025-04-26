using Movie.API.DTOs.Director;
using Movie.API.Models;

namespace Movie.API.Services
{
    public interface IDirectorService
    {
        Task<IEnumerable<DirectorResponseDto>> GetAllDirectors();
        Task<DirectorResponseDto> GetDirectorById(string id);
        Task<DirectorResponseDto> CreateDirector(DirectorCreateDto directorCreateDto);
        Task<bool> UpdateDirector(string id, DirectorUpdateDto directorUpdateDto);
        Task<bool> DeleteDirector(string id);
    }
}
