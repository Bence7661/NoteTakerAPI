using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NoteTakerAPI.Models;

namespace NoteTakerAPI.Data.EntityTypeConfigurations;

public class NoteConfiguration : IEntityTypeConfiguration<Note>
{
    public void Configure(EntityTypeBuilder<Note> builder)
    {
        builder.HasKey(n => n.Id);

        builder.Property(n => n.Title)
            .HasMaxLength(50);

        builder.Property(n => n.Body)
            .HasMaxLength(1000);

        builder.HasOne(n => n.Notebook)
            .WithMany(nb => nb.Notes)
            .HasForeignKey(n => n.NotebookId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
