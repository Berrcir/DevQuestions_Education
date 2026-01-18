namespace DevQuestions.Contracts.Questions
{
    public record class QuestionCreateDto(string Title, string Text, Guid UserId, Guid[]? TagIds);
}