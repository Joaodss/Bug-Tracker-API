using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugTracker.Models;

[Table("TicketComments")]
public class TicketComment
{
    [Key, Column("id")]
    public long Id { get; set; }

    [Required, Column("timestamp", TypeName = "datetime2")]
    public DateTime TimeStamp { get; } = DateTime.Now;

    [Required, Column("content")]
    public string content { get; set; }

    // -------------------- Model Relations --------------------
    // Many to One
    [Required, ForeignKey("ticket_id")]
    public long TicketId { get; set; }

    public virtual Ticket Ticket { get; set; }

    // Many to One
    [Required, ForeignKey("user_id")]
    public Guid UserId { get; set; }

    public virtual User User { get; set; }
}