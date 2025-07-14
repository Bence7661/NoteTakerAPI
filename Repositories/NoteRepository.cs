using NoteTakerAPI.Data;
using NoteTakerAPI.Models;

namespace NoteTakerAPI.Repositories;

public class NoteRepository(NotesDbContext context) : Repository<Note>(context), INoteRepository
{
}