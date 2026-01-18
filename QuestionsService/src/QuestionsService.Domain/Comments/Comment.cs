namespace DirectoryService.Domain.Comments
{
    public class Comment
    {
        public Guid Id { get; set; }

        public required Guid UserId { get; set; }

        public required string Text { get; set; }

        public required Guid Parent { get; set; }

        public required string ParentType { get; set; }
    }
}