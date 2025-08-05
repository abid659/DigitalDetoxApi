using System.ComponentModel.DataAnnotations;

namespace DigitalDetox.API.Models;

public class StudentResponse
{
    [Key]
    public int ResponseId { get; set; }

    public int StudentId { get; set; }
    public Student? Student { get; set; }

    public int QuestionId { get; set; }
    public Question? Question { get; set; }

    public bool Answer { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;

}
