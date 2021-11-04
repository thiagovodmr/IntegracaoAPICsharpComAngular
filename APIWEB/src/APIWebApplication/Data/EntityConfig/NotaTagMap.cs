using APIWebApplication.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIWebApplication.Data.EntityConfig
{
    public class NotaTagMap : IEntityTypeConfiguration<NotaTag>
    {
        public void Configure(EntityTypeBuilder<NotaTag> builder)
        {
            builder.HasOne(t => t.Nota)
                .WithMany(n => n.Tags)
                .HasForeignKey(t => t.NotaId);

            builder.HasOne(t => t.Tag)
                .WithMany(n => n.TagNotas)
                .HasForeignKey(t => t.TagId);

            builder.HasIndex(nt => new { nt.NotaId, nt.TagId})
                    .IsUnique();
        }
    }
}
