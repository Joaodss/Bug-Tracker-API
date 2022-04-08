using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugTracker.Models;

[Table("Companies")]
public class Company
{
    [Key] [Column("id")]
    public long Id { get; set; }

    [Required] [Column("created_at")]
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;

    [Required] [Column("name")]
    public string Name { get; set; }

    // Many to Many
    public virtual IEnumerable<User> Admins { get; set; }

    // Many to Many
    public virtual IEnumerable<User> Users { get; set; }

    // One to Many
    [InverseProperty("Company")]
    public virtual IEnumerable<Project> Projects { get; set; }
}