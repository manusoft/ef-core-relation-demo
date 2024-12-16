using EFCoreRelation.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreRelation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OneToOneController(AppDbContext context) : ControllerBase
{
    [HttpPost("add-user")]
    public async Task<IActionResult> AddUser(User user)
    {
        context.Users.Add(user);
        await context.SaveChangesAsync();
        return Ok();
    }

    [HttpPost("get-users")]
    public async Task<IActionResult> GetUsers()
    {
        return Ok(await context.Users.Include(x => x.Profile).ToListAsync());
    }

    [HttpPost("add-profile")]
    public async Task<IActionResult> AddProfile(Profile profile)
    {
        context.Profiles.Add(profile);
        await context.SaveChangesAsync();
        return Ok();
    }

    [HttpPost("get-profiles")]
    public async Task<IActionResult> GetProfiles()
    {
        return Ok(await context.Profiles.Include(x => x.User).ToListAsync());
    }
}

public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public Profile? Profile { get; set; }
}

public class Profile
{
    public int Id { get; set; }
    public string Bio { get; set; } = null!;

    public int UserId { get; set; }
    public User? User { get; set; }
}
