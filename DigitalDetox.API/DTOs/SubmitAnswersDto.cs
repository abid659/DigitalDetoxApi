namespace DigitalDetox.API.DTOs;

public class SubmitAnswersDto
{
    public int StudentId { get; set; }

    // Array of 8 answers (QuestionId + Answer)
    public List<AnswerDto> Answers { get; set; } = new();
}