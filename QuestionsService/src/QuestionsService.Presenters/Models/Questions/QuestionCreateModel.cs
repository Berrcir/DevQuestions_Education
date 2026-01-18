namespace DirectoryService.Presenters.Models.Questions
{
    public record class QuestionCreateModel(string Title, string Text, Guid UserId, Guid[]? TagIds);
}