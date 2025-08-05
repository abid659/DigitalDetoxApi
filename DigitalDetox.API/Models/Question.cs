using System.ComponentModel.DataAnnotations;

namespace DigitalDetox.API.Models;

public class Question
{
    public int QuestionId { get; set; }
    
    [MaxLength(50)]
    public string? QuestionText { get; set; }

    public ICollection<StudentResponse>? StudentResponses { get; set; }
}
