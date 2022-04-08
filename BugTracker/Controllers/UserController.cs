using BugTracker.Data;
using BugTracker.DTOs.User;
using BugTracker.Models;
using BugTracker.Utils;
using Microsoft.AspNetCore.Mvc;

namespace BugTracker.Controllers;

[ApiController] [Route("api/user")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly IUnityOfWork _unityOfWork;

    public UserController(ILogger<UserController> logger, IUnityOfWork unityOfWork)
    {
        _logger = logger;
        _unityOfWork = unityOfWork;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        _logger.LogInformation("Getting all users");

        var users = _unityOfWork.UsersRepository.GetAllWithRoles()
            .Select(user => user.AsDto())
            .ToList();

        return Ok(users);
    }

    [HttpGet("{guid}")]
    public IActionResult GetById(string guid)
    {
        Guid validGuid;
        try
        {
            validGuid = Guid.Parse(guid);
        }
        catch (FormatException e)
        {
            _logger.LogError(e, "Invalid guid format: {0}", e.Message);
            return BadRequest(new {message = $"Invalid guid format: {e.Message}"});
        }

        _logger.LogInformation("Getting user by id: {0}", validGuid);

        var user = _unityOfWork.UsersRepository.GetByIdWithRoles(validGuid);

        if (user is not null)
        {
            _logger.LogWarning("User with id: {guid} not found", validGuid);
            return NotFound("User not found");
        }

        return Ok(user.AsDto());
    }


    [HttpPost]
    public IActionResult Post(CreateUserDto createUser)
    {
        _logger.LogInformation("Creating new user");

        var user = createUser.AsUser();

        const string defaultRoleType = "User";
        var userRole = _unityOfWork.RolesRepository.GetByName(defaultRoleType) ?? new Role {Name = defaultRoleType};

        _unityOfWork.RolesRepository.Attach(userRole);

        user.Role = userRole;

        _unityOfWork.UsersRepository.Add(user);

        _unityOfWork.Complete();

        return Created("", user.AsDto());
    }
}