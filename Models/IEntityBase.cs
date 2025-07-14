namespace NoteTakerAPI.Models;

/// <summary>
/// Base class for all entities
/// </summary>
public interface IEntityBase 
{
    /// <summary>
    /// Unique identifier
    /// </summary>
    public int Id { get; set; }
}
