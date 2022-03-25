using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugTracker.Models;

[Table("Companies")]
public class Company
{
    [Key, Column("id")]
    public long Id { get; set; }

    [Required, Column("created_at", TypeName = "datetime2")]
    public DateTime CreatedAt { get; } = DateTime.Now;

    [Required, Column("name")]
    public string Name { get; set; }

    // -------------------- Model Relations --------------------
    // Many to Many
    public virtual ICollection<User> Admins { get; set; }

    // Many to Many
    public virtual ICollection<User> Users { get; set; }

    // One to Many
    [InverseProperty("Company")]
    public virtual ICollection<Project> Projects { get; set; }

    // One to Many
    [InverseProperty("Company")]
    public virtual ICollection<Ticket> Tickets { get; set; }
}