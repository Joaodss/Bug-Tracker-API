using BugTracker.DTOs;
using BugTracker.Models;

namespace BugTracker.Utils;

public static class UserExtensions
{
    // User - UserDTO
    public static UserDTO AsDto(this User user)
    {
        return new UserDTO
        {
            Id = user.Id,
            CreatedAt = user.CreatedAt,
            Email = user.Email,
            Name = user.Name,
            PhotoUrl = user.PhotoUrl ?? "",
            RoleName = user.Role.Name
        };
    }

    // CreateUserDTO - User
    public static User AsUser(this CreateUserDTO dto)
    {
        return new User
        {
            Email = dto.Email,
            Password = dto.Password,
            Name = dto.Name,
            PhotoUrl = dto.PhotoUrl,
            OwnedCompanies = new List<Company>(),
            AssignedCompanies = new List<Company>(),
            OwnedProjects = new List<Project>(),
            AssignedProjects = new List<Project>(),
            OwnedTickets = new List<Ticket>(),
            AssignedTickets = new List<Ticket>(),
            TicketComments = new List<TicketComment>()
        };
    }

    // UpdateUserDTO - User
}