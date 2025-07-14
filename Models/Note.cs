namespace NoteTakerAPI.Models;

public class Note
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public required string Body { get; set; }
    public int NotebookId { get; set; }
    public required Notebook Notebook { get; set; }
}
