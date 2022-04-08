using BugTracker.Data.Repositories;

namespace BugTracker.Data;

public interface IUnityOfWork
{
    IUsersRepository UsersRepository { get; }
    IRolesRepository RolesRepository { get; }
    ICompaniesRepository CompaniesRepository { get; }
    IProjectsRepository ProjectsRepository { get; }
    ITicketsRepository TicketsRepository { get; }
    ITicketCommentsRepository TicketCommentsRepository { get; }
    
    void Complete();
}