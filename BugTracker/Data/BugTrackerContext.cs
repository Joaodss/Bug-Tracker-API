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

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     const string connectionString = @"Database=BugTracker;UserID=BugTracker-admin;Password=BugTracker-123;";
    //     optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
    //         .LogTo(Console.WriteLine, LogLevel.Information)
    //         .EnableSensitiveDataLogging()
    //         .EnableDetailedErrors();
    // }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasDefaultSchema("BugTracker");

        modelBuilder.Entity<Company>()
            .HasMany(company => company.Admins)
            .WithMany(user => user.OwnedCompanies)
            .UsingEntity(entity => entity.ToTable("OwnedUserCompanies"));

        modelBuilder.Entity<Company>()
            .HasMany(company => company.Users)
            .WithMany(user => user.AssignedCompanies)
            .UsingEntity(entity => entity.ToTable("AssignedUserCompanies"));

        modelBuilder.Entity<Project>()
            .HasMany(project => project.ProjectOwners)
            .WithMany(user => user.OwnedProjects)
            .UsingEntity(entity => entity.ToTable("OwnedUserProjects"));

        modelBuilder.Entity<Project>()
            .HasMany(project => project.AssignedUsers)
            .WithMany(user => user.AssignedProjects)
            .UsingEntity(entity => entity.ToTable("AssignedUserProjects"));

        modelBuilder.Entity<Ticket>()
            .HasMany(ticket => ticket.TicketOwners)
            .WithMany(user => user.OwnedTickets)
            .UsingEntity(entity => entity.ToTable("OwnedUserTickets"));

        modelBuilder.Entity<Ticket>()
            .HasMany(ticket => ticket.AssignedUsers)
            .WithMany(user => user.AssignedTickets)
            .UsingEntity(entity => entity.ToTable("AssignedUserTickets"));
    }
}