using System.Data.Common;
using System.Linq.Expressions;
using BugTracker.Data;
using Dapper;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.Repositories.Impl;

public class BaseRepository<TEntity> : IBaseRepository<TEntity>, IDisposable where TEntity : class
{
    private readonly ILogger<BaseRepository<TEntity>> _logger;
    private readonly BugTrackerContext _context;
    private readonly DbSet<TEntity> _dbSet;
    private readonly DbConnection _connection;
    private readonly string _entityName;

    public BaseRepository(ILogger<BaseRepository<TEntity>> logger, BugTrackerContext context)
    {
        _logger = logger;
        _context = context;
        _dbSet = _context.Set<TEntity>();
        _connection = _context.Database.GetDbConnection();
        _entityName = typeof(TEntity).Name + "s";
    }

    public virtual TEntity? GetById(long id)
    {
        _logger.LogInformation("Getting {0} by id: {1}", _entityName, id);

        var query = $"SELECT * FROM \"BugTracker\".\"{_entityName}\" WHERE id = @Id";

        return _connection.Query<TEntity>(query, new {Entity = _entityName, Id = id}).FirstOrDefault();
    }

    public virtual TEntity? GetById(Guid guid)
    {
        _logger.LogInformation("Getting {0} by guid: {1}", _entityName, guid);

        var query = $"SELECT * FROM \"BugTracker\".\"{_entityName}\" WHERE id = @Guid";

        return _connection.Query<TEntity>(query, new {Entity = _entityName, Guid = guid}).FirstOrDefault();
    }

    public virtual IEnumerable<TEntity> GetAll()
    {
        _logger.LogInformation("Getting all {0}", _entityName);

        var query = $"SELECT * FROM \"BugTracker\".\"{_entityName}\"";

        _logger.LogInformation("Query: {0}", query);

        return _connection.Query<TEntity>(query);
    }

    public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
    {
        _logger.LogInformation("Finding {0} by predicate", _entityName);

        return _dbSet.Where(predicate);
    }

    public virtual void Add(TEntity entity)
    {
        _logger.LogInformation("Adding {0}", _entityName);

        _dbSet.Add(entity);
    }

    public virtual void AddRange(IEnumerable<TEntity> entities)
    {
        _logger.LogInformation("Adding multiple {0}", _entityName);

        _dbSet.AddRange(entities);
    }

    public virtual void Update(TEntity entity)
    {
        _logger.LogInformation("Updating {0}", _entityName);

        _dbSet.Update(entity);
    }

    public virtual void Delete(TEntity entity)
    {
        _logger.LogInformation("Deleting {0}", _entityName);

        _dbSet.Remove(entity);
    }

    public virtual void DeleteById(long id)
    {
        _logger.LogInformation("Deleting {0} by id: {1}", _entityName, id);

        var entity = GetById(id);

        if (entity is null)
        {
            _logger.LogWarning("{0} with id: {1} not found", _entityName, id);
            return;
        }

        Delete(entity);
    }

    public virtual void DeleteById(Guid guid)
    {
        _logger.LogInformation("Deleting {0} by guid: {1}", _entityName, guid);

        var entity = GetById(guid);

        if (entity is null)
        {
            _logger.LogWarning("{0} with guid: {1} not found", _entityName, guid);
            return;
        }

        Delete(entity);
    }

    public virtual void DeleteRange(IEnumerable<TEntity> entities)
    {
        _logger.LogInformation("Deleting multiple {0}", _entityName);

        _dbSet.RemoveRange(entities);
    }

    public virtual void Save()
    {
        _logger.LogInformation("Saving changes");

        _context.SaveChanges();
    }


    public void Dispose()
    {
        Dispose(true);

        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposing)
        {
            return;
        }

        _context.Dispose();
    }
}