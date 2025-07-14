using Microsoft.EntityFrameworkCore;
using NoteTakerAPI.Data.Seeders;
using NoteTakerAPI.Models;
using System.Reflection;

namespace NoteTakerAPI.Data;

public class NotesDbContext(DbContextOptions<NotesDbContext> options) : DbContext(options)
{
    public DbSet<User> User { get; set; }
    public DbSet<Notebook> Notebook { get; set; }
    public DbSet<Note> Note { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        UserSeeder.Seed(modelBuilder);
    }
}
