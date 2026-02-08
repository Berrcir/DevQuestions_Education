namespace DevQuestions.Contracts.Questions
{
    public record class UpdateQuestionDto(string Title, string Text, Guid[]? TagIds);
}