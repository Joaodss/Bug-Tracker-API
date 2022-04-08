using BugTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.Data.Repositories.Impl;

public class CompaniesRepository : BaseRepository<Company>, ICompaniesRepository
{
    public CompaniesRepository(ILogger<BaseRepository<Company>> logger, DbContext context) : base(logger, context)
    {
    }
}