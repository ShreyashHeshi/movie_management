﻿using Movie.API.Models;

namespace Movie.API.Repositories
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movies>> GetAllMovies();
        Task<Movies> GetMovieById(string id);
        Task<IEnumerable<Movies>> GetMoviesByDirector(string directorId);
        Task<Movies> CreateMovie(Movies movie);
        Task<bool> UpdateMovie(string id, Movies movie);
        Task<bool> DeleteMovie(string id);
    }
}
