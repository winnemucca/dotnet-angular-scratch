using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace API.Controllers;

[Authorize]
public class UsersController(DataContext context): BaseApiController
{
    [AllowAnonymous]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
        //Database.EnsureCreated()
        var users = await context.Users.ToListAsync();
        return users;
    }

     [HttpGet("{id:int}")]
    public async Task<ActionResult<AppUser>> GetUser(int id) // api/users/3
    {
        var user = await context.Users.FindAsync(id);

        if (user == null) return NotFound();
        return user;
    }
}