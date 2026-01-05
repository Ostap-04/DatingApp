using DatingApp.API.Data;
using DatingApp.API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Controllers;

[Route("[controller]")]
[ApiController]
public class MembersController : Controller
{
    private readonly AppDbContext _context;
    
    public MembersController(AppDbContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<AppUser>>> GetMembers()
    {
        var members = await _context.Users.ToListAsync();
        return members;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AppUser>> GetMember(string id)
    {
        var member = await _context.Users.FindAsync(id);
        if (member == null)
        {
            return NotFound();
        }
        
        return member;
    }   
}