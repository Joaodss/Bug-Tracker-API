using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FastEnumUtility;

namespace BugTracker.Models;

[Table("Tickets")]
public class Ticket
{
    [Key] [Column("id")]
    public long Id { get; set; }

    [Required] [Column("created_at")]
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;

    [Required] [Column("title")]
    public string Title { get; set; }

    [Required] [Column("description")]
    public string Description { get; set; }


    // Enums are not stored in the database, so we need to store the string value of the enum
    [Required] [Column("status")]
    public string StatusString
    {
        get => Status.ToName();
        set => Status = FastEnum.Parse<TicketStatus>(value, true);
    }

    [Required] [Column("type")]
    public string TypeString
    {
        get => Type.ToName();
        set => Type = FastEnum.Parse<TicketType>(value, true);
    }

    [Required] [Column("priority")]
    public string PriorityString
    {
        get => Priority.ToName();
        set => Priority = FastEnum.Parse<TicketPriority>(value, true);
    }

    [NotMapped]
    private TicketStatus Status { get; set; }

    [NotMapped]
    private TicketType Type { get; set; }

    [NotMapped]
    private TicketPriority Priority { get; set; }

    // Many to One
    [Required] [ForeignKey("project_id")] [Column("project_id")]
    public long ProjectId { get; set; }

    public virtual Project Project { get; set; }

    // One to Many
    [InverseProperty("Ticket")]
    public virtual IEnumerable<TicketComment> TicketComments { get; set; }

    // Many to Many
    public virtual IEnumerable<User> TicketOwners { get; set; }

    // Many to Many
    public virtual IEnumerable<User> AssignedUsers { get; set; }
}

public enum TicketPriority
{
    Low,
    Medium,
    High,
    Urgent
}

public enum TicketType
{
    Bug,
    Feature,
    Task,
    Other
}

public enum TicketStatus
{
    Open,
    InProgress,
    Resolved,
    Closed
}