namespace DevQuestions.Contracts.Questions
{
    public record class CreateQuestionDto(string Title, string Text, Guid UserId, Guid[]? TagIds);
}