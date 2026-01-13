namespace DirectoryService.Domain.Tags
{
    public record class Tag
    {
        public Guid Id { get; set; }
        public required string Name { get; init; }
        public required string Desciption { get; init; }
    }
}
