namespace DevQuestions.Contracts.Questions
{
    public record class GetQuestionsDto(string SearchText, Guid[]? TagIds, int PageSize);
}