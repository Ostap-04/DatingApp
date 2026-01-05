using DatingApp.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Data;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
    {
    }
    
    public DbSet<AppUser> Users { get; set; }
}