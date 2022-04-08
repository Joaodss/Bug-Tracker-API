using BugTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.Data.Repositories.Impl;

public class TicketCommentsRepository : BaseRepository<TicketComment>, ITicketCommentsRepository
{
    public TicketCommentsRepository(ILogger<BaseRepository<TicketComment>> logger, DbContext context) :
        base(logger, context)
    {
    }
}