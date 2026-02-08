namespace DevQuestions.Presenters.Questions.Models
{
    public record class GetQuestionsModel(string SearchText, Guid[]? TagIds, int PageSize);
}