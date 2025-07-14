using NoteTakerAPI.Models.Enums;

namespace NoteTakerAPI.Models;

public class Notebook : IEntityBase
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public NotebookColor Color { get; set; }
    public int UserId { get; set; }
    public required User User { get; set; }
    public ICollection<Note>? Notes { get; set; }
}
