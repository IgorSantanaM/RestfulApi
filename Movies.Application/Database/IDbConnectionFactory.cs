﻿using System.Data;

namespace Movies.Application.Database
{
    public interface IDbConnectionFactory
    {
        Task<IDbConnection> CeateConnectionAsync(CancellationToken token = default);
    }
}
