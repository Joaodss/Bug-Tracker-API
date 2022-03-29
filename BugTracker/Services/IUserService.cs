using BugTracker.DTOs;
using BugTracker.Models;

namespace BugTracker.Services.Impl;

public interface IUserService
{
    IEnumerable<User> GetAllUsers();
    User? GetUserById(string guid);
    User? GetUserByEmail(string email);
    bool IsValidEmail(string email);
    User? CreateUser(User newUser);
    void UpdateUser(string guid, User updateUser);
    void DeleteUser(string guid);
}

