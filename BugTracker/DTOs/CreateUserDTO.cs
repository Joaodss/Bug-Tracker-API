using System.ComponentModel.DataAnnotations;
using BugTracker.Models;

namespace BugTracker.DTOs;

public record CreateUserDTO
{
    [Required]
    [EmailAddress]
    public string Email { get; init; }

    [Required]
    [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.",
        MinimumLength = 6)]
    public string Password { get; init; }

    [Required]
    public string Name { get; init; }

    public string? PhotoUrl { get; init; }
}