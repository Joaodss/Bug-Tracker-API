using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugTracker.Models;

[Table("TicketComments")]
public class TicketComment
{
    [Key] [Column("id")]
    public long Id { get; set; }

    [Required] [Column("created_at")]
    public DateTime TimeStamp { get; init; } = DateTime.UtcNow;

    [Required] [Column("content")]
    public string content { get; set; }

    // Many to One
    [Required] [ForeignKey("ticket_id")] [Column("ticket_id")]
    public long TicketId { get; set; }

    public virtual Ticket Ticket { get; set; }

    // Many to One
    [Required] [ForeignKey("user_id")] [Column("user_id")]
    public Guid UserId { get; set; }

    public virtual User User { get; set; }
}