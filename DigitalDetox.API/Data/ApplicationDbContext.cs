using Microsoft.EntityFrameworkCore;
using DigitalDetox.API.Models;

namespace DigitalDetox.API.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<StudentResponse> StudentResponses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Seed questions
        modelBuilder.Entity<Question>().HasData(
            new Question { QuestionId = 1, QuestionText = "প্রতিদিন ২ লিটার পানি পান করেছি?" },
            new Question { QuestionId = 2, QuestionText = "আজ আমার মা বা বাবাকে বলেছি ভালোবাসি?" },
            new Question { QuestionId = 3, QuestionText = "আজ ফোন ২ ঘন্টার কম ব্যবহার করেছি?" },
            new Question { QuestionId = 4, QuestionText = "এই সপ্তাহে আমি কাউকে সাহায্য করেছি?" },
            new Question { QuestionId = 5, QuestionText = "এই সপ্তাহে আমি কোনো বই পড়েছি?" },
            new Question { QuestionId = 6, QuestionText = "বাবা-মার সাথে খাওয়ার সময় কাটিয়েছি?" },
            new Question { QuestionId = 7, QuestionText = "নিজের শরীরের খেয়াল রেখেছি?" },
            new Question { QuestionId = 8, QuestionText = "রাত ১১ টার আগেই ঘুমিয়ে পড়েছি?" }
        );
    }
}