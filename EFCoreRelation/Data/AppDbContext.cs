using EFCoreRelation.Controllers;
using Microsoft.EntityFrameworkCore;

namespace EFCoreRelation.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    
}