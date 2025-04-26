using Movie.API.DTOs.Director;
using Movie.API.Models;
using Movie.API.Repositories;
using AutoMapper;

namespace Movie.API.Services
{
    public class DirectorService : IDirectorService
    {
        private readonly IDirectorRepository _directorRepository;
        private readonly IMapper _mapper;

        public DirectorService(IDirectorRepository directorRepository, IMapper mapper)
        {
            _directorRepository = directorRepository;
            _mapper = mapper;
        }

        public async Task<DirectorResponseDto> CreateDirector(DirectorCreateDto directorCreateDto)
        {
            var director = _mapper.Map<Director>(directorCreateDto);
            await _directorRepository.CreateDirector(director);
            return _mapper.Map<DirectorResponseDto>(director);
        }

        public async Task<bool> DeleteDirector(string id)
        {
            return await _directorRepository.DeleteDirector(id);
        }

        public async Task<IEnumerable<DirectorResponseDto>> GetAllDirectors()
        {
            var directors = await _directorRepository.GetAllDirectors();
            return _mapper.Map<IEnumerable<DirectorResponseDto>>(directors);
        }

        public async Task<DirectorResponseDto> GetDirectorById(string id)
        {
            var director = await _directorRepository.GetDirectorById(id);
            return _mapper.Map<DirectorResponseDto>(director);
        }

        public async Task<bool> UpdateDirector(string id, DirectorUpdateDto directorUpdateDto)
        {
            var existingDirector = await _directorRepository.GetDirectorById(id);
            if (existingDirector == null)
                return false;

            _mapper.Map(directorUpdateDto, existingDirector);
            return await _directorRepository.UpdateDirector(id, existingDirector);
        }
    }
}
