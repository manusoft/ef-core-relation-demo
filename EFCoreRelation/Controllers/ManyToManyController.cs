using EFCoreRelation.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreRelation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ManyToManyController(AppDbContext context) : ControllerBase
{
    [HttpPost("add-student")]
    public async Task<IActionResult> AddStudent(Student student)
    {
        context.Students.Add(student);
        await context.SaveChangesAsync();
        return Ok();
    }

    [HttpPost("get-students")]
    public async Task<IActionResult> GetStudents()
    {
        return Ok(await context.Students.Include(x => x.StudentsCourses).ToListAsync());
    }

    [HttpPost("add-course")]
    public async Task<IActionResult> AddCourse(Course course)
    {
        context.Courses.Add(course);
        await context.SaveChangesAsync();
        return Ok();
    }

    [HttpPost("get-courses")]
    public async Task<IActionResult> GetCourses()
    {
        return Ok(await context.Courses.Include(x => x.StudentsCourses).ToListAsync());
    }

    [HttpPost("add-student-course")]
    public async Task<IActionResult> AddStudentCourse(StudentCourse studentCourse)
    {
        context.StudentsCourses.Add(studentCourse);
        await context.SaveChangesAsync();
        return Ok();
    }

    [HttpPost("get-students-courses")]
    public async Task<IActionResult> GetStudentsCourses()
    {
        return Ok(await context.StudentsCourses.Include(x => x.Student).Include(x => x.Course).ToListAsync());
    }
}

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    public ICollection<StudentCourse>? StudentsCourses { get; set; }
}

public class Course
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    public ICollection<StudentCourse>? StudentsCourses { get; set; }
}

public class StudentCourse
{
    public int Id { get; set; }

    public int StudentId { get; set; }
    public Student? Student { get; set; }

    public int CourseId { get;set; }
    public Course? Course { get; set; }
}