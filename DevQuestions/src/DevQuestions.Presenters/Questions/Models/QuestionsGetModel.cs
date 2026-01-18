namespace DevQuestions.Presenters.Questions.Models
{
    public record class QuestionsGetModel(string SearchText, Guid[]? TagIds, int PageSize);
}