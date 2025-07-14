namespace NoteTakerAPI.Models;

public class User : IEntityBase
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Password { get; set; } //This is just a practice project chill.
    public virtual ICollection<Notebook>? Notebooks { get; set; }
}
