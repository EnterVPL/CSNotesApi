public class Note
{
    public Guid Id { get; set; } = Guid.NewGuid(); // Use UUID v7
    public string Title { get; set; }
    public string Content { get; set; }
}