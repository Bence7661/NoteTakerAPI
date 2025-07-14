using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NoteTakerAPI.Models;

namespace NoteTakerAPI.EntityTypeConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);

        builder.Property(u => u.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(u => u.Password)
            .HasMaxLength(200)
            .IsRequired();

        builder.HasMany(u => u.Notebooks)
            .WithOne(n => n.User)
            .HasForeignKey(nameof(Notebook.UserId))
            .OnDelete(DeleteBehavior.Cascade);
    }
}
