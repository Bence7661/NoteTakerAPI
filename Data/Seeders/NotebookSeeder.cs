using Microsoft.EntityFrameworkCore;
using NoteTakerAPI.Models;

namespace NoteTakerAPI.Data.Seeders;

public class NotebookSeeder
{
    public static void Seed(ModelBuilder modelBuilder)
        => modelBuilder.Entity<Notebook>().HasData(
            new Notebook 
            {
                Id = 1,
                Name = "TestNotebook",
                Color = Models.Enums.NotebookColor.Green,
                UserId = 1,
            }
        );
}
