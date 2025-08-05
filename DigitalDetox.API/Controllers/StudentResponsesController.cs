using DigitalDetox.API.Data;
using DigitalDetox.API.DTOs;
using DigitalDetox.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DigitalDetox.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentResponsesController(ApplicationDbContext context) : ControllerBase
{
    [HttpPost("submit")]
    public async Task<IActionResult> SubmitAnswers([FromBody] SubmitAnswersDto dto)
    {
        // Prevent duplicate submission for today based on local time
        var today = DateTime.Now.Date;

        var alreadySubmitted = await context.StudentResponses
            .AnyAsync(r => r.StudentId == dto.StudentId && r.CreatedAt.Date == today);

        if (alreadySubmitted)
            return BadRequest("You have already submitted today's answers.");

        // Save all responses
        foreach (var answer in dto.Answers)
        {
            context.StudentResponses.Add(new StudentResponse
            {
                StudentId = dto.StudentId,
                QuestionId = answer.QuestionId,
                Answer = answer.Answer,
                CreatedAt = DateTime.Now
            });
        }

        await context.SaveChangesAsync();

        return Ok(new { message = "Responses submitted successfully." });
    }
}