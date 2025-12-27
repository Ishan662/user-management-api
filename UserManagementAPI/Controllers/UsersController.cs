using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private static List<User> users = new();

    [HttpGet]
    public IActionResult GetUsers() => Ok(users);

    [HttpGet("{id}")]
    public IActionResult GetUser(int id)
    {
        var user = users.FirstOrDefault(u =>u.Id == id);
        return user == null ? NotFound() : Ok(user);
    }

    [HttpPost]
    public IActionResult CreateUser(User user)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        users.Add(user);
        return Ok(User);    

    }

    [HttpPut("{id}")]
    public IActionResult UpdateUser(int id, User updatedUser)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var user = users.FirstOrDefault(u => u.Id == id);
        if (user == null) return NotFound();

        user.Name = updatedUser.Name;
        user.Email = updatedUser.Email;
        return Ok(user);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUser(int id)
    {
        var user = users.FirstOrDefault(u => u.Id == id);
        if (user == null) return NotFound();

        users.Remove(user);
        return NoContent();
    }
}
    