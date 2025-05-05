using Microsoft.EntityFrameworkCore;
using RailRay.API.Models.Domain;

namespace RailRay.API.Data
{
    public class RailRayDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TrainSchedule>()
                .HasOne(ts => ts.FromStation)
                .WithMany(s => s.DepartingSchedules)
                .HasForeignKey(ts => ts.FromStationId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TrainSchedule>()
                .HasOne(ts => ts.ToStation)
                .WithMany(s => s.ArrivingSchedules)
                .HasForeignKey(ts => ts.ToStationId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BookingSeat>()
       .Property(bs => bs.Price)
       .HasPrecision(18, 2);

            modelBuilder.Entity<Payment>()
                .Property(p => p.Amount)
                .HasPrecision(18, 2);
        }

        public RailRayDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
                
        }



        public DbSet<User> Users { get; set; }
        public DbSet<Train> Trains { get; set; }
        public DbSet<TrainSchedule> Scedules { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<BookingSeat> Seats { get; set; }
        public DbSet<Station> Stations { get; set; }


    }



    }
