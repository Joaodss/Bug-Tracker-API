using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.Models;

[Table("Users")]
public class User
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("id")]
    public Guid Id { get; set; }

    [Required, Column("created_at")]
    public DateTime CreatedAt { get; } = DateTime.Now;

    [Required, Column("email")]
    public string Email { get; set; }

    [Required, Column("password")]
    public string Password { get; set; }

    [Required, Column("name")]
    public string Name { get; set; }

    [Required, Column("photo_url")]
    public string PhotoURL { get; set; }

    // -------------------- Model Relations --------------------
    // Many to One
    [Required, ForeignKey("role_id")]
    public int RoleId { get; set; }

    public Role Role { get; set; }

    // Many to Many
    public virtual ICollection<Company> OwnedCompanies { get; set; }

    // Many to Many
    public virtual ICollection<Company> AssignedCompanies { get; set; }

    // Many to Many
    public virtual ICollection<Project> OwnedProjects { get; set; }

    // Many to Many
    public virtual ICollection<Project> AssignedProjects { get; set; }

    // Many to Many
    public virtual ICollection<Ticket> OwnedTickets { get; set; }

    // Many to Many
    public virtual ICollection<Ticket> AssignedTickets { get; set; }

    // One to Many
    [InverseProperty("User")]
    public virtual ICollection<TicketComment> TicketComments { get; set; }
}