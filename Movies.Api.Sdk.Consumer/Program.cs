using Microsoft.Extensions.DependencyInjection;
using Movies.Api.Sdk;
using Movies.Contracts.Requests;
using Refit;
using System.Text.Json;

//var moviesApi = RestService.For<IMoviesApi>("https://localhost:5001");

var services = new ServiceCollection();

var provider = services.BuildServiceProvider();

services.AddRefitClient<IMoviesApi>()
    .ConfigureHttpClient(x =>
        x.BaseAddress = new Uri("https://localhost:5001"));

var moviesApi = provider.GetRequiredService<IMoviesApi>();

var movie = await moviesApi.GetMovieAsync("nick-the-greek-2022");

var request = new GetAllMoviesRequest
{
    Title = null,
    Year = null,
    SortBy = null,
    Page = 1,
    PageSize = 3,
};

var movies = await moviesApi.GetMoviesAsync(request);

Console.WriteLine(JsonSerializer.Serialize(movie));