using System.Net.Mail;
using BugTracker.Data;
using BugTracker.DTOs;
using BugTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.Services.Impl;

public class UserService : IUserService
{
    private readonly ILogger<UserService> _logger;
    private readonly BugTrackerContext _context;

    public UserService(BugTrackerContext context, ILogger<UserService> logger)
    {
        _context = context;
        _logger = logger;
    }


    public IEnumerable<User> GetAllUsers()
    {
        _logger.LogInformation("Getting all users");

        return _context.Users.ToList();
    }

    public User? GetUserById(string guid)
    {
        _logger.LogInformation("Getting user by id, id: {0}", guid);

        return _context.Users.FirstOrDefault(user => user.Id == Guid.Parse(guid));
    }

    public User? GetUserByEmail(string email)
    {
        _logger.LogInformation("Getting user by email: {0}", email);

        return _context.Users.FirstOrDefault(user => user.Email == email);
    }

    public bool IsValidEmail(string email)
    {
        _logger.LogInformation("Checking if email: {0} is valid", email);

        if (GetUserByEmail(email) is not null)
        {
            _logger.LogInformation("Email is already in use");

            return false;
        }

        return MailAddress.TryCreate(email, out _);
    }

    public User? CreateUser(User newUser)
    {
        _logger.LogInformation("Creating new user with email: {0}", newUser.Email);

        _context.Add(newUser);

        _context.SaveChanges();

        var savedUser = GetUserByEmail(newUser.Email);

        if (savedUser is null)
        {
            _logger.LogError("Failed to create user");

            return null;
        }

        _logger.LogInformation("User created with id: {0}", savedUser.Id);

        return savedUser;
    }

    public void UpdateUser(string guid, User updateUser)
    {
        _logger.LogInformation("Updating user with id: {0}", guid);

        var userToUpdate = GetUserById(guid);

        if (userToUpdate is null)
        {
            _logger.LogError("User not found");

            return;
        }

        _context.SaveChanges();
    }


    public void DeleteUser(string guid)
    {
        _logger.LogInformation("Deleting user with id: {0}", guid);

        var user = GetUserById(guid);

        if (user is null)
        {
            _logger.LogError("User not found");

            return;
        }

        _context.Users.Remove(user);

        _context.SaveChanges();

        _logger.LogInformation("User deleted");
    }
}