using DatingApp.API.Data;
using DatingApp.API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Controllers;

[Authorize]
public class MembersController : BaseApiController
{
    private readonly AppDbContext _context;
    
    public MembersController(AppDbContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<AppUser>>> GetMembers(CancellationToken token = default)
    {
        var members = await _context.Users.ToListAsync(token);
        return members;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AppUser>> GetMember(string id, CancellationToken token = default)
    {
        var member = await _context.Users.FindAsync([id], token);
        if (member == null)
        {
            return NotFound();
        }
        
        return member;
    }   
}