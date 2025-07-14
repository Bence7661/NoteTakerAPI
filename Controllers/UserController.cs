using Microsoft.AspNetCore.Mvc;
using NoteTakerAPI.Models;
using NoteTakerAPI.Repositories;

namespace NoteTakerAPI.Controllers;

/// <summary>
/// Manages users in the system.
/// </summary>
[Route("api/[controller]")]
public class UserController(IUserRepository userRepository) : BaseApiController<User>(userRepository)
{
}