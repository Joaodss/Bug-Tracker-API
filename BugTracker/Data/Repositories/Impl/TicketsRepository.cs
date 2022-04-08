using BugTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.Data.Repositories.Impl;

public class TicketsRepository : BaseRepository<Ticket>, ITicketsRepository
{
    public TicketsRepository(ILogger<BaseRepository<Ticket>> logger, DbContext context) : base(logger, context)
    {
    }
}