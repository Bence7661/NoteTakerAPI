using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NoteTakerAPI.Models;

namespace NoteTakerAPI.Data.EntityTypeConfigurations;

public class NotebookConfiguration : IEntityTypeConfiguration<Notebook>
{
    public void Configure(EntityTypeBuilder<Notebook> builder)
    {
        builder.HasKey(nb => nb.Id);

        builder.Property(nb => nb.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(nb => nb.Color)
            .IsRequired();

        builder.HasOne(nb => nb.User)
            .WithMany(u => u.Notebooks)
            .HasForeignKey(nb => nb.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(nb => nb.Notes)
            .WithOne(n => n.Notebook)
            .HasForeignKey(n => n.NotebookId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
