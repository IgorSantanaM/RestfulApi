using Movies.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Application.Repositories
{
    public interface IMovieRepository
    {
        Task<bool> CreateAsync(Movie movie);

        Task<Movie> GetAsync(Guid id);

        Task<IEnumerable<Movie>> GetAllAsync();

        Task<bool> UpdateAsync(Movie movie);

        Task DeleteAsync(Guid id);
    }
}
