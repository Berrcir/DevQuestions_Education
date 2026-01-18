namespace DevQuestions.Contracts.Questions
{
    public record class QuestionsGetDto(string SearchText, Guid[]? TagIds, int PageSize);
}