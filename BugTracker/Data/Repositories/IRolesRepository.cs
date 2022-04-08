using BugTracker.Models;

namespace BugTracker.Data.Repositories;

public interface IRolesRepository : IBaseRepository<Role>
{
    Role? GetByName(string name);
}