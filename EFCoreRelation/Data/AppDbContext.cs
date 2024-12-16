using EFCoreRelation.Controllers;
using Microsoft.EntityFrameworkCore;

namespace EFCoreRelation.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    // One To One
    public DbSet<User> Users => Set<User>();
    public DbSet<Profile> Profiles => Set<Profile>();
}