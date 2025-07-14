using NoteTakerAPI.Data;
using NoteTakerAPI.Models;

namespace NoteTakerAPI.Repositories;

public class NotebookRepository(NotesDbContext context) : Repository<Notebook>(context), INotebookRepository
{
}