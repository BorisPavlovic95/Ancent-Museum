using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Config
{
    public class ExhibitConfig : IEntityTypeConfiguration<Exhibits>
    {
        public void Configure(EntityTypeBuilder<Exhibits> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Description).IsRequired();
            builder.Property(p => p.Price).IsRequired();
            builder.Property(p => p.PictureUrl).IsRequired();
            builder.Property(p => p.Century).IsRequired();
            builder.Property(p => p.Period).IsRequired();
            builder.HasOne(b => b.ExhibitCulture).WithMany()
                .HasForeignKey(p => p.ExhibitCultureId);
            builder.HasOne(t => t.ExhibitType).WithMany()
                .HasForeignKey(p => p.ExhibitTypeId);
        }
    }
}
