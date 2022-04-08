using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugTracker.Models;

[Table("Projects")]
public class Project
{
    [Key] [Column("id")]
    public long Id { get; set; }

    [Required] [Column("created_at")]
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;

    [Required] [Column("title")]
    public string Title { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    // Many to One
    [Required] [ForeignKey("company_id")] [Column("company_id")]
    public long CompanyId { get; set; }

    public virtual Company Company { get; set; }

    // One to Many
    [InverseProperty("Project")]
    public virtual IEnumerable<Ticket> Tickets { get; set; }

    // Many to Many
    public virtual IEnumerable<User> ProjectOwners { get; set; }

    // Many to Many
    public virtual IEnumerable<User> AssignedUsers { get; set; }
}