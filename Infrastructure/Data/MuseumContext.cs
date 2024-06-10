using Core.Entities;
using Core.Entities.TourAggregate;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using System.Reflection;

namespace Infrastructure.Data
{
    public class MuseumContext : DbContext
    {
        public MuseumContext(DbContextOptions<MuseumContext> options) : base(options)
        {
        }
        public DbSet<Exhibits> Exhibits { get; set; }

        public DbSet<ExhibitType> ExhibitTypes { get; set; }

        public DbSet<ExhibitCulture> ExhibitCulture { get; set; }

        public DbSet<Tour> Tours { get; set; }

        public DbSet<TourItem> TourItems { get; set; }

        public DbSet<ExhibitRatingComment> ExhibitRatingComments { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Tour>().OwnsOne(x => x.UserData);
            modelBuilder.Entity<TourItem>().OwnsOne(x => x.ExhibitItemToured);

            modelBuilder.Entity<ExhibitRatingComment>()
                        .HasOne(e => e.Tour)
                        .WithMany() // Assuming a Tour can have multiple ExhibitRatingComments
                        .HasForeignKey(e => e.TourId)
                        .OnDelete(DeleteBehavior.Cascade);

            

        }

    }


}
