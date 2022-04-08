using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugTracker.Models;

public class User
{
    [Key] [DatabaseGenerated(DatabaseGeneratedOption.Identity)] [Column("id")]
    public Guid Id { get; set; }

    [Required] [Column("created_at")]
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;

    [Required] [Column("email")]
    public string Email { get; set; }

    [Required] [Column("password")]
    public string Password { get; set; }

    [Required] [Column("name")]
    public string Name { get; set; }

    [Column("photo_url")]
    public string? PhotoUrl { get; set; }

    // Many to One: Roles - User
    [Required] [ForeignKey("role_id")] [Column("role_id")]
    public int RoleId { get; set; }

    public Role Role { get; set; }

    // Many to Many: Users - Owned - Companies
    public virtual IEnumerable<Company> OwnedCompanies { get; set; }

    // Many to Many: Users - Assigned - Companies
    public virtual IEnumerable<Company> AssignedCompanies { get; set; }

    // Many to Many: Users - Owned - Projects
    public virtual IEnumerable<Project> OwnedProjects { get; set; }

    // Many to Many: Users - Assigned - Projects
    public virtual IEnumerable<Project> AssignedProjects { get; set; }

    // Many to Many: Users - Owned - Tickets
    public virtual IEnumerable<Ticket> OwnedTickets { get; set; }

    // Many to Many: Users - Assigned - Tickets
    public virtual IEnumerable<Ticket> AssignedTickets { get; set; }

    // One to Many: User - Comments
    [InverseProperty("User")] 
    public virtual IEnumerable<TicketComment> TicketComments { get; set; }
}