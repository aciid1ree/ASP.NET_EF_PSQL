using ApplicationStore.Core.Models;
using ApplicationStore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationStore.DataAccess.Configuration
{
    public class ApplicationConfiguration : IEntityTypeConfiguration<ApplicationEntity>
    {
        public void Configure(EntityTypeBuilder<ApplicationEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(b => b.Author)
                .IsRequired();

            builder.Property(b => b.Name)
                .HasMaxLength(Application.MAX_NAME_LENGTH)
               .IsRequired();

            builder.Property(b => b.Description)
               .HasMaxLength(Application.MAX_DESCRIPTION_LENGTH);

            builder.Property(b => b.Outline)
               .HasMaxLength(Application.MAX_OUTLINE_LENGTH);


        }
    }
}
