using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugTracker.Models;

[Table("Projects")]
public class Project
{
    [Key, Column("id")]
    public long Id { get; set; }

    [Required, Column("created_at", TypeName = "datetime2")]
    public DateTime CreatedAt { get; } = DateTime.Now;

    [Required, Column("title")]
    public string Title { get; set; }

    [Required, Column("description")]
    public string Description { get; set; }

    // -------------------- Model Relations --------------------
    // Many to One
    [Required, ForeignKey("company_id")]
    public string CompanyId { get; set; }

    public virtual Company Company { get; set; }

    // One to Many
    [InverseProperty("Project")]
    public virtual ICollection<Ticket> Tickets { get; set; }

    // Many to Many
    public virtual ICollection<User> ProjectOwners { get; set; }

    // Many to Many
    public virtual ICollection<User> AssignedUsers { get; set; }
}