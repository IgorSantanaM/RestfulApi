using Microsoft.Extensions.DependencyInjection;
using Movies.Application.Database;
using Movies.Application.Repositories;
using Movies.Application.Services;
using FluentValidation;

namespace Movies.Application
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddSingleton<IMovieRepository, MovieRepository>();
            services.AddSingleton<IMovieService, MovieService>();
            services.AddValidatorsFromAssemblyContaining<IApplicationMarker>(lifetime: ServiceLifetime.Singleton);
            return services;
        }

        public static IServiceCollection AddDatabase(this IServiceCollection services, string connectionString)
        {
            services.AddSingleton<IDbConnectionFactory>(_ =>
                new NpgSqlConnectionFactory(connectionString));

            services.AddSingleton<DbInitializer>();

            return services;
        }
    }
}
