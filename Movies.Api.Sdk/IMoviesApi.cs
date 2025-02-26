using Movies.Contracts.Requests;
using Movies.Contracts.Responses;
using Refit;

namespace Movies.Api.Sdk
{
    [Headers("Auuthorization: Bearer")]
    public interface IMoviesApi
    {
        [Get(Endpoints.Movies.Get)]
        Task<MoviesResponse> GetMovieAsync(string idOrSlug);

        [Get(Endpoints.Movies.GetAll)]
        Task<MoviesResponse> GetMoviesAsync(GetAllMoviesRequest request);

        [Post(Endpoints.Movies.Create)]
        Task<MoviesResponse> CreateMovieAsync(CreateMovieRequest request);

        [Put(Endpoints.Movies.Update)]
        Task<MoviesResponse> UpdateMovieAsync(Guid id,UpdateMovieRequest request);

        [Delete(Endpoints.Movies.Delete)]
        Task DeleteMovieAsync(Guid id);

        [Put(Endpoints.Movies.Rate)]
        Task RateAsync(Guid id, RateMovieRequest request);

        [Delete(Endpoints.Movies.DeleteRating)]
        Task DeleteRatingAsync(Guid id);

        [Get(Endpoints.Ratings.GetUserRatings)]
        Task<IEnumerable<MovieRatingResponse>> GetUserRatingsAsync();
    }
}
