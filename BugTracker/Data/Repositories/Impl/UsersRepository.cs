using BugTracker.Models;
using Dapper;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.Data.Repositories.Impl;

public class UsersRepository : BaseRepository<User>, IUsersRepository
{
    public UsersRepository(ILogger<BaseRepository<User>> logger, DbContext context) : base(logger, context)
    {
    }

    public IEnumerable<User> GetAllWithRoles()
    {
        _logger.LogInformation("Getting all users with roles");

        const string query = @"
            SELECT * FROM ""BugTracker"".""Users"" AS u 
            LEFT JOIN ""BugTracker"".""Roles"" AS r 
            ON u.""role_id"" = r.""id""";

        return _connection.Query<User, Role, User>(query,
            (user, role) =>
            {
                user.Role = role;
                return user;
            });
    }

    public User? GetByIdWithRoles(Guid guid)
    {
        _logger.LogInformation("Getting user with roles by id: {0}", guid);

        const string query = @"
            SELECT * FROM ""BugTracker"".""Users"" AS u 
            LEFT JOIN ""BugTracker"".""Roles"" AS r 
            ON u.""role_id"" = r.""id"" 
            WHERE u.""id"" = @Guid";

        var parameters = new {Guid = guid};

        return _connection.Query<User, Role, User>(query,
                (user, role) =>
                {
                    user.Role = role;
                    return user;
                },
                parameters)
            .FirstOrDefault();
    }
}