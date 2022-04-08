using BugTracker.Models;
using Dapper;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.Data.Repositories.Impl;

public class RolesRepository : BaseRepository<Role>, IRolesRepository
{
    public RolesRepository(ILogger<BaseRepository<Role>> logger, DbContext context) : base(logger, context)
    {
    }

    public Role? GetByName(string name)
    {
        _logger.LogInformation($"Getting role by name: {name}");

        const string query = @"
            SELECT * FROM ""BugTracker"".""Roles"" AS r
            WHERE r.""name"" = @Name";

        var parameters = new {Name = name};

        return _connection.Query<Role>(query, parameters)
            .FirstOrDefault();
    }
}