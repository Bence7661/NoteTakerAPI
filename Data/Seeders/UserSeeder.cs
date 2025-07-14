using Microsoft.EntityFrameworkCore;
using NoteTakerAPI.Models;

namespace NoteTakerAPI.Data.Seeders;

public class UserSeeder
{
    public static void Seed(ModelBuilder modelBuilder)
        => modelBuilder.Entity<User>().HasData(
            new User { Id = 1, Name = "Serious", Password = "password" }
        );
}
