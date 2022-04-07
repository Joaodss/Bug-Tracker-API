using System.Linq.Expressions;

namespace BugTracker.Repositories;

public interface IBaseRepository<TEntity> where TEntity : class
{
    TEntity? GetById(long id);
    TEntity? GetById(Guid guid);
    IEnumerable<TEntity> GetAll();
    IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

    void Add(TEntity entity);
    void AddRange(IEnumerable<TEntity> entities);

    void Update(TEntity entity);

    void DeleteById(long id);
    void DeleteById(Guid guid);
    void Delete(TEntity entity);
    void DeleteRange(IEnumerable<TEntity> entities);

    void Save();
}