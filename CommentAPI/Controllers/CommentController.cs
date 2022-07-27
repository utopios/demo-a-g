using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CommentAPI.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
[EnableCors("all")]
public class CommentController : ControllerBase
{
    private List<Comment> fakeComments = new List<Comment>()
    {
        new Comment("comment 1", 1),
        new Comment("comment 2", 1),
        new Comment("comment 3", 2),
        new Comment("comment 4", 2)
    };

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        List<Comment> comments = fakeComments.Where(c => c.ProductId == id).ToList();
        if (comments.Count > 0)
            return Ok(comments);
        else
            return NotFound();
    }
}

public  record  Comment(string Content, int ProductId);