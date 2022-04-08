using BugTracker.Models;

namespace BugTracker.Data.Repositories;

public interface IUsersRepository : IBaseRepository<User>
{
    IEnumerable<User> GetAllWithRoles();
    User? GetByIdWithRoles(Guid guid);
}