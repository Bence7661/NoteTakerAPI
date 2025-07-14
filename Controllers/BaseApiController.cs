using Microsoft.AspNetCore.Mvc;
using NoteTakerAPI.Models;
using NoteTakerAPI.Repositories;

namespace NoteTakerAPI.Controllers;

/// <summary>
/// Base controller. Provides all must have funcionalities for controllers deriving from it.
/// </summary>
#pragma warning disable CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do). Reason: Won't document cancellation token.
[ApiController]
public abstract class BaseApiController<TEntity>(IRepository<TEntity> repository) : ControllerBase
    where TEntity : class, IEntityBase
{

    /// <summary>
    /// Gets all entities.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public virtual async Task<ActionResult<IEnumerable<TEntity>>> GetAll(CancellationToken cancellationToken)
    {
        var result = await repository.GetAllAsync(cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Gets an entity by Id.
    /// </summary>
    /// <param name="id">Entity ID.</param>
    /// <returns>Entity if found; otherwise, 404.</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<TEntity>> GetById(int id, CancellationToken cancellationToken)
    {
        var result = await repository.GetByIdAsync(id, cancellationToken);
        if (result == null) return NotFound();
        return Ok(result);
    }

    /// <summary>
    /// Creates a new entity.
    /// </summary>
    /// <param name="entity">Entity to create.</param>
    /// <returns>The created entity.</returns>
    [HttpPost]
    public async Task<ActionResult<TEntity>> Create(TEntity entity, CancellationToken cancellationToken)
    {
        await repository.AddAsync(entity, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = entity.Id }, entity);
    }

    /// <summary>
    /// Deletes an entity by Id.
    /// </summary>
    /// <param name="id">Entity Id.</param>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var result = await repository.GetByIdAsync(id, cancellationToken);
        if (result == null) return NotFound();
        repository.Remove(result);
        await repository.SaveChangesAsync(cancellationToken);
        return NoContent();
    }
}
#pragma warning restore CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
