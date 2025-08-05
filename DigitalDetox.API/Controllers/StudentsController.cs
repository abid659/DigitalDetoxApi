using DigitalDetox.API.Data;
using DigitalDetox.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DigitalDetox.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentsController(ApplicationDbContext context) : ControllerBase
{
    // GET: api/Students/verify?class=3&roll=12
    [HttpGet("verify")]
    public async Task<IActionResult> VerifyStudent(int @class, int roll)
    {
        var student = await context.Students
            .FirstOrDefaultAsync(s => s.Class == @class && s.Roll == roll);

        if (student == null)
            return NotFound("Student not found");

        return Ok(new
        {
            student.StudentId,
            student.Name,
            student.Class,
            student.Roll
        });
    }
}