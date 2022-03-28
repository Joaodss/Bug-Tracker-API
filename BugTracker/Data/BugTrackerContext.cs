using BugTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.Data;

public class BugTrackerContext : DbContext
{
    public BugTrackerContext(DbContextOptions<BugTrackerContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<TicketComment> Comments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("BugTracker");

        // Users - Owned - Companies
        modelBuilder.Entity<User>()
            .HasMany(user => user.OwnedCompanies)
            .WithMany(company => company.Admins)
            .UsingEntity<Dictionary<string, object>>(
                "OwnedUsersCompanies",
                entity => entity
                    .HasOne<Company>()
                    .WithMany()
                    .HasForeignKey("CompanyId")
                    .OnDelete(DeleteBehavior.Cascade),
                entity => entity
                    .HasOne<User>()
                    .WithMany()
                    .HasForeignKey("UserId")
                    .OnDelete(DeleteBehavior.Cascade));


        // Users - Assigned - Companies
        modelBuilder.Entity<User>()
            .HasMany(user => user.AssignedCompanies)
            .WithMany(company => company.Users)
            .UsingEntity<Dictionary<string, object>>(
                "AssignedUsersCompanies",
                entity => entity
                    .HasOne<Company>()
                    .WithMany()
                    .HasForeignKey("CompanyId")
                    .OnDelete(DeleteBehavior.Cascade),
                entity => entity
                    .HasOne<User>()
                    .WithMany()
                    .HasForeignKey("UserId")
                    .OnDelete(DeleteBehavior.Cascade));

        // Users - Owned - Projects
        modelBuilder.Entity<User>()
            .HasMany(user => user.OwnedProjects)
            .WithMany(project => project.ProjectOwners)
            .UsingEntity<Dictionary<string, object>>(
                "OwnedUsersProjects",
                entity => entity
                    .HasOne<Project>()
                    .WithMany()
                    .HasForeignKey("ProjectId")
                    .OnDelete(DeleteBehavior.Cascade),
                entity => entity
                    .HasOne<User>()
                    .WithMany()
                    .HasForeignKey("UserId")
                    .OnDelete(DeleteBehavior.Cascade));

        // Users - Assigned - Projects
        modelBuilder.Entity<User>()
            .HasMany(user => user.AssignedProjects)
            .WithMany(project => project.AssignedUsers)
            .UsingEntity<Dictionary<string, object>>(
                "AssignedUsersProjects",
                entity => entity
                    .HasOne<Project>()
                    .WithMany()
                    .HasForeignKey("ProjectId")
                    .OnDelete(DeleteBehavior.Cascade),
                entity => entity
                    .HasOne<User>()
                    .WithMany()
                    .HasForeignKey("UserId")
                    .OnDelete(DeleteBehavior.Cascade));

        // Users - Owned - Tickets
        modelBuilder.Entity<User>()
            .HasMany(user => user.OwnedTickets)
            .WithMany(ticket => ticket.TicketOwners)
            .UsingEntity<Dictionary<string, object>>(
                "OwnedUsersTickets",
                entity => entity
                    .HasOne<Ticket>()
                    .WithMany()
                    .HasForeignKey("TicketId")
                    .OnDelete(DeleteBehavior.Cascade),
                entity => entity
                    .HasOne<User>()
                    .WithMany()
                    .HasForeignKey("UserId")
                    .OnDelete(DeleteBehavior.Cascade));

        // Users - Assigned - Tickets
        modelBuilder.Entity<User>()
            .HasMany(user => user.AssignedTickets)
            .WithMany(ticket => ticket.AssignedUsers)
            .UsingEntity<Dictionary<string, object>>(
                "AssignedUsersTickets",
                entity => entity
                    .HasOne<Ticket>()
                    .WithMany()
                    .HasForeignKey("TicketId")
                    .OnDelete(DeleteBehavior.Cascade),
                entity => entity
                    .HasOne<User>()
                    .WithMany()
                    .HasForeignKey("UserId")
                    .OnDelete(DeleteBehavior.Cascade));
    }
}