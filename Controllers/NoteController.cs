using Microsoft.AspNetCore.Mvc;
using NoteTakerAPI.Models;
using NoteTakerAPI.Repositories;

namespace NoteTakerAPI.Controllers;

/// <summary>
/// Manages notes in the system.
/// </summary>
[Route("api/[controller]")]
public class NoteController(INoteRepository noteRepository) : BaseApiController<Note>(noteRepository)
{
}