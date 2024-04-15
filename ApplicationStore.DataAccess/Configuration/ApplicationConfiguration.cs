namespace ApplicationStore.DataAccess.Configuration;
using ApplicationStore.Core.Models;
using ApplicationStore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
public class ApplicationConfiguration : IEntityTypeConfiguration<ApplicationEntity>
{
    public void Configure(EntityTypeBuilder<ApplicationEntity> builder)
    {
        builder.HasKey(x => x.id);
        builder.Property(b => b.author)
            .IsRequired();
        builder.Property(b => b.name)
            .HasMaxLength(Application.MaxNameLength)
            .IsRequired();
        builder.Property(b => b.description)
            .HasMaxLength(Application.MaxDescriptionLength);
        builder.Property(b => b.outline)
            .HasMaxLength(Application.MaxOutlineLength);
    }
}