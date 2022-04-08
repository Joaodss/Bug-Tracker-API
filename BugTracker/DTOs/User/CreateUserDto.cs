using System.ComponentModel.DataAnnotations;

namespace BugTracker.DTOs.User;

public record CreateUserDto
{
    [Required]
    [EmailAddress]
    [StringLength(100, ErrorMessage = "The {0} must be at at max {1} characters long.")]
    public string Email { get; init; }

    [Required]
    [StringLength(100, MinimumLength = 6,
        ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.")]
    public string Password { get; init; }

    [Required]
    [StringLength(50, ErrorMessage = "The {0} must be at at max {1} characters long.")]
    public string Name { get; init; }

    public string? PhotoUrl { get; init; }
}