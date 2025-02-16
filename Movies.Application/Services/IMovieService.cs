using Movies.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Application.Services
{
    public interface IMovieService
    {
        Task<bool> CreateAsync(Movie movie, CancellationToken token = default);

        Task<Movie> GetByIdAsync(Guid id, CancellationToken token = default);

        Task<Movie> GetBySlugAsync(string slug, CancellationToken token = default);

        Task<IEnumerable<Movie>> GetAllAsync(CancellationToken token = default);

        Task<Movie?> UpdateAsync(Movie movie, CancellationToken token = default);

        Task<bool> DeleteAsync(Guid id, CancellationToken token = default);

        public Task<bool> ExistsByIdAsync(Guid id, CancellationToken token = default);
    }
}