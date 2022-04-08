using BugTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.Data.Repositories.Impl;

public class ProjectsRepository : BaseRepository<Project>, IProjectsRepository
{
    public ProjectsRepository(ILogger<BaseRepository<Project>> logger, DbContext context) : base(logger, context)
    {
    }
}