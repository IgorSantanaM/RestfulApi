using FluentValidation;
using Movies.Application.Models;
using Movies.Application.Repositories;

namespace Movies.Application.Services
{
    public class MovieService : IMovieService
    {

        private readonly IMovieRepository _movieRepository;
        private readonly IValidator<Movie> _validator;

        public MovieService(IMovieRepository movieRepository, IValidator<Movie> validator)
        {
            _movieRepository = movieRepository;
            _validator = validator;
        }

        public async Task<bool> CreateAsync(Movie movie, CancellationToken token = default)
        {
            await _validator.ValidateAndThrowAsync(movie, token);
            return await _movieRepository.CreateAsync(movie, token);
        }

        public async Task<bool> DeleteAsync(Guid id, CancellationToken token = default) =>
            await _movieRepository.DeleteAsync(id, token);

        public async Task<bool> ExistsByIdAsync(Guid id, CancellationToken token = default) =>
            await _movieRepository.ExistsByIdAsync(id, token);

        public async Task<IEnumerable<Movie>> GetAllAsync(CancellationToken token = default) =>
            await _movieRepository.GetAllAsync(token);

        public async Task<Movie> GetByIdAsync(Guid id, CancellationToken token = default) =>
            await _movieRepository.GetByIdAsync(id, token);

        public async Task<Movie> GetBySlugAsync(string slug, CancellationToken token = default) =>
            await _movieRepository.GetBySlugAsync(slug, token);

        public async Task<Movie?> UpdateAsync(Movie movie, CancellationToken token = default)
        {
            await _validator.ValidateAndThrowAsync(movie, token);

            var movieExists = await _movieRepository.ExistsByIdAsync(movie.Id);
            if (!movieExists) return null;

            await _movieRepository.UpdateAsync(movie, token);
            return movie;
        }
    }
}