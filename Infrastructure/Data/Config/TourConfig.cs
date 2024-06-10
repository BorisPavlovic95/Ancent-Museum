using Core.Entities.TourAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Config
{
    public class TourConfig : IEntityTypeConfiguration<Tour>
    {
        public void Configure(EntityTypeBuilder<Tour> builder)
        {
            builder.OwnsOne(o => o.UserData, a =>
            {
                a.WithOwner();

            });
            builder.Navigation(a => a.UserData).IsRequired();
            builder.Property(s => s.Status)
                .HasConversion(
                    o => o.ToString(),
                    o => (TourStatus)Enum.Parse(typeof(TourStatus), o));

            builder.HasMany(o => o.TourItems).WithOne().OnDelete(DeleteBehavior.Cascade);
        }
    }
}
