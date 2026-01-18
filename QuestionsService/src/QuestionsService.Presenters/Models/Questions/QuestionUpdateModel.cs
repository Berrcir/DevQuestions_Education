namespace DirectoryService.Presenters.Models.Questions
{
    public record class QuestionUpdateModel(string Title, string Text, Guid[]? TagIds);
}