using DigitalDetox.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DigitalDetox.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LeaderboardController(ApplicationDbContext _context) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetLeaderboard(DateTime? fromDate, DateTime? toDate, int? classFilter)
    {
        var query = _context.StudentResponses
            .Include(r => r.Student)
            .AsQueryable();

        // Filter by from date
        if (fromDate.HasValue)
        {
            query = query.Where(r => r.CreatedAt.Date >= fromDate.Value.Date);
        }

        // Filter by to date (inclusive to full day)
        if (toDate.HasValue)
        {
            var endOfDay = toDate.Value.Date.AddDays(1).AddTicks(-1);
            query = query.Where(r => r.CreatedAt <= endOfDay);
        }

        // Filter by class if specified
        if (classFilter.HasValue)
        {
            query = query.Where(r => r.Student != null && r.Student.Class == classFilter.Value);
        }

        var leaderboard = await query
            .GroupBy(r => new { r.Student.StudentId, r.Student.Name, r.Student.Class, r.Student.Roll })
            .Select(g => new
            {
                StudentId = g.Key.StudentId,
                Name = g.Key.Name,
                Class = g.Key.Class,
                Roll = g.Key.Roll,
                YesCount = g.Count(x => x.Answer)
            })
            .OrderByDescending(x => x.YesCount)
            .ToListAsync();

        return Ok(leaderboard);
    }

}
