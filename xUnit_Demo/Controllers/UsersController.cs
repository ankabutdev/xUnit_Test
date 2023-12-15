using Microsoft.AspNetCore.Mvc;
using xUnit_Demo.Models;
using xUnit_Demo.Services.Users;

namespace xUnit_Demo.Controllers;

[Route("api/users")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _userService.GetAllUsers();
        return Ok(users);
    }

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetUserById(int userId)
    {
        var user = await _userService.GetByIdAsync(userId);
        if (user == null)
            return NotFound();

        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] User user)
    {
        if (user == null)
            return BadRequest();

        var result = await _userService.CreateAsync(user);

        if (result)
            return CreatedAtAction(nameof(GetUserById), new { userId = user.Id }, user);
        else
            return StatusCode(StatusCodes.Status500InternalServerError);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateUser([FromBody] User user)
    {
        if (user == null || user.Id <= 0)
            return BadRequest();

        var result = await _userService.UpdateAsync(user.Id, user);

        return Ok(result);
    }

    [HttpDelete("{userId}")]
    public async Task<IActionResult> DeleteUser(int userId)
    {
        var result = await _userService.DeleteAsync(userId);

        return Ok(result);
    }
}
