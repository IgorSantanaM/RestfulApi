﻿using Microsoft.Extensions.Diagnostics.HealthChecks;
using Movies.Application.Database;

namespace Movies.Api.Health
{
    public class DatabaseHealthCheck : IHealthCheck
    {
        public const string Name = "Database";
        private readonly IDbConnectionFactory _connectionFactory;
        private readonly ILogger<DatabaseHealthCheck> _logger;

        public DatabaseHealthCheck(IDbConnectionFactory connectionFactory, ILogger<DatabaseHealthCheck> logger)
        {
            _connectionFactory = connectionFactory;
            _logger = logger;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            try
            {
                _ = await _connectionFactory.CreateConnectionAsync(cancellationToken);
                return HealthCheckResult.Healthy();
            }
            catch (Exception ex)
            {
                const string errorMessage = "Database is Unhealthy";
                _logger.LogError(errorMessage, ex);
                return HealthCheckResult.Unhealthy(errorMessage, ex);
            }

        }
    }
}
