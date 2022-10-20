using System.Net.Mime;
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
        user.Name = "Mock name";
        user.Age = 99;

        if(id == 2)
        {
            return NotFound();
        }

        return Ok(user);
    }
}

