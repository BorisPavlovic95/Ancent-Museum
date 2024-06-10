using Core.Entities.TourAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Config
{
    public class TourItemConfig : IEntityTypeConfiguration<TourItem>
    {
        public void Configure(EntityTypeBuilder<TourItem> builder)
        {
            builder.OwnsOne(i => i.ExhibitItemToured, io => { io.WithOwner(); });

        }
    }
}
