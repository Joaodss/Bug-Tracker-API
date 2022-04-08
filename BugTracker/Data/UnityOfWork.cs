using BugTracker.Data.Repositories;

namespace BugTracker.Data;

public class UnityOfWork : IUnityOfWork, IDisposable
{
    private readonly BugTrackerContext _context;
    private readonly ILogger<UnityOfWork> _logger;

    public UnityOfWork(
        ILogger<UnityOfWork> logger,
        BugTrackerContext context,
        IUsersRepository usersRepository,
        IRolesRepository rolesRepository,
        ICompaniesRepository companiesRepository,
        IProjectsRepository projectsRepository,
        ITicketsRepository ticketsRepository,
        ITicketCommentsRepository ticketCommentsRepository
    )
    {
        _logger = logger;
        _context = context;
        UsersRepository = usersRepository;
        RolesRepository = rolesRepository;
        CompaniesRepository = companiesRepository;
        ProjectsRepository = projectsRepository;
        TicketsRepository = ticketsRepository;
        TicketCommentsRepository = ticketCommentsRepository;
    }

    public IUsersRepository UsersRepository { get; }
    public IRolesRepository RolesRepository { get; }
    public ICompaniesRepository CompaniesRepository { get; }
    public IProjectsRepository ProjectsRepository { get; }
    public ITicketsRepository TicketsRepository { get; }
    public ITicketCommentsRepository TicketCommentsRepository { get; }

    public void Complete()
    {
        _logger.LogInformation("Transaction Saved");

        _context.SaveChanges();
    }

    private bool _disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed && disposing)
        {
            _context.Dispose();
        }

        _disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}