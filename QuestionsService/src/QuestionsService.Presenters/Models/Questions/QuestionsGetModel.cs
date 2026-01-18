namespace DirectoryService.Presenters.Models.Questions
{
    public record class QuestionsGetModel(string SearchText, Guid[]? TagIds, int PageSize);
}