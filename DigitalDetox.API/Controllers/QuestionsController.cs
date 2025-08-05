using DigitalDetox.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DigitalDetox.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QuestionsController(ApplicationDbContext context) : ControllerBase
{
    // GET: api/Questions
    [HttpGet]
    public async Task<IActionResult> GetQuestions()
    {
        var questions = await context.Questions
            .OrderBy(q => q.QuestionId)
            .Select(q => new
            {
                q.QuestionId,
                q.QuestionText
            })
            .ToListAsync();

        return Ok(questions);
    }
}