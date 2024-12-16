using EFCoreRelation.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreRelation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OneToManyController(AppDbContext context) : ControllerBase
{
    [HttpPost("add-blog")]
    public async Task<IActionResult> AddBlog(Blog blog)
    {
        context.Blogs.Add(blog);
        await context.SaveChangesAsync();
        return Ok();
    }

    [HttpPost("get-blogs")]
    public async Task<IActionResult> GetBlogs()
    {
        return Ok(await context.Blogs.Include(x => x.Posts).ToListAsync());
    }

    [HttpPost("add-post")]
    public async Task<IActionResult> AddPost(Post post)
    {
        context.Posts.Add(post);
        await context.SaveChangesAsync();
        return Ok();
    }

    [HttpPost("get-posts")]
    public async Task<IActionResult> GetPosts()
    {
        return Ok(await context.Posts.Include(x => x.Blog).ToListAsync());
    }
}

public class Blog
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;

    public ICollection<Post>? Posts { get; set; }
}

public class Post
{
    public int Id { get; set; }
    public string Content { get; set; } = null!;

    public int BlogId { get; set; }
    public Blog? Blog { get; set; }
}