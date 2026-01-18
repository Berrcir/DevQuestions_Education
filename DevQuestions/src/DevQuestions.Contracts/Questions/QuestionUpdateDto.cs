namespace DevQuestions.Contracts.Questions
{
    public record class QuestionUpdateDto(string Title, string Text, Guid[]? TagIds);
}