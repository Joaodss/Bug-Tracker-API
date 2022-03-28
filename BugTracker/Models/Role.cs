using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugTracker.Models;

[Table("Roles")]
public class Role
{
    [Key] [Column("id")]
    public int Id { get; set; }

    [Required] [Column("name")]
    public string Name { get; set; }

    // One to Many: Role - Users
    [InverseProperty("Role")]
    public virtual ICollection<User> Users { get; set; }
}