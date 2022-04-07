using BugTracker.Data;
using BugTracker.Models;
using BugTracker.Repositories;
using BugTracker.Repositories.Impl;
using BugTracker.Services;
using BugTracker.Services.Impl;
using Microsoft.EntityFrameworkCore;
using Serilog;

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddUserSecrets<Program>(true)
    .AddEnvironmentVariables()
    .Build();
// -------------------- Configure Logger --------------------
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(configuration)
    .CreateLogger();

// -------------------- Configure builder --------------------
var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();

builder.Services.AddControllers();

builder.Services.AddDbContext<BugTrackerContext>(options => options
    .UseNpgsql(@"Host=localhost;Database=BugTracker;Username=postgres;Password=123admin")
    .EnableSensitiveDataLogging()
    .EnableDetailedErrors()
);

builder.Services.AddScoped<ITicketCommentService, TicketCommentService>();
builder.Services.AddScoped<ITicketCommentsRepository, TicketCommentsRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

try
{
    Log.Information("Starting web host");
    
    app.UseSerilogRequestLogging();
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();

    return 0;
}
catch (Exception e)
{
    Log.Fatal(e, "Host terminated unexpectedly");

    return 1;
}
finally
{
    Log.CloseAndFlush();
}