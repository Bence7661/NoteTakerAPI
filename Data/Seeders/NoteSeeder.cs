using Microsoft.EntityFrameworkCore;
using NoteTakerAPI.Models;

namespace NoteTakerAPI.Data.Seeders;

public class NoteSeeder
{
    public static void Seed(ModelBuilder modelBuilder)
        => modelBuilder.Entity<Note>().HasData(
            new Note 
            { 
                Id = 1,
                Title = "Test note title",
                Body = "Test note body.",
                NotebookId = 1,
            }
        );
}
