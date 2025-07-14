using Microsoft.AspNetCore.Mvc;
using NoteTakerAPI.Models;
using NoteTakerAPI.Repositories;

namespace NoteTakerAPI.Controllers;

/// <summary>
/// Manages notebooks in the system.
/// </summary>
[Route("api/[controller]")]
public class NotebookController(INotebookRepository notebookRepository) : BaseApiController<Notebook>(notebookRepository)
{
}