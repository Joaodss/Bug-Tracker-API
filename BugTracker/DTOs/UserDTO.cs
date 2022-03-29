namespace BugTracker.DTOs;

public record UserDTO
{
    public Guid Id { get; init; }
    public DateTime CreatedAt { get; init; }
    public string Email { get; init; }
    public string Name { get; init; }
    public string PhotoUrl { get; init; }
    public string RoleName { get; init; }
}