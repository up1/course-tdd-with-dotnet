using Microsoft.AspNetCore.Mvc;

namespace src.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;

    public UserController(ILogger<UserController> logger)
    {
        _logger = logger;
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var user = new User();
        user.Id = id;
        user.Name = "Somkiat";
        user.Age = 30;
        return Ok(user);
    }
}

