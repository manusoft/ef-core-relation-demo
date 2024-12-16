using EFCoreRelation.Controllers;
using Microsoft.EntityFrameworkCore;

namespace EFCoreRelation.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    // One To One
    public DbSet<User> Users => Set<User>();
    public DbSet<Profile> Profiles => Set<Profile>();

    // One To Many
    public DbSet<Blog> Blogs => Set<Blog>();
    public DbSet<Post> Posts => Set<Post>();

    // Many To Many
    public DbSet<Student> Students => Set<Student>();
    public DbSet<Course> Courses => Set<Course>();
    public DbSet<StudentCourse> StudentsCourses => Set<StudentCourse>();
}