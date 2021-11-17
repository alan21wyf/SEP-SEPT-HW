using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class CabAppDbContext:DbContext
    {
        public CabAppDbContext(DbContextOptions<CabAppDbContext> options):base(options)
        {

        }

        public DbSet<CabType> CabTypes { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Bookings> Bookings { get; set; }
        public DbSet<BookingsHistory> BookingsHistories { get; set; }
        
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CabType>(ConfigureCabType);
            modelBuilder.Entity<Place>(ConfigurePlace);
            modelBuilder.Entity<Bookings>(ConfigureBookings);
            modelBuilder.Entity<BookingsHistory>(ConfigureBookingsHistory);
        }

        private void ConfigureCabType(EntityTypeBuilder<CabType> builder)
        {
            builder.ToTable("CabTypes");
            builder.HasKey(c => c.CabTypeId);
            builder.Property(c => c.CabTypeName).HasColumnType("varchar").HasMaxLength(30);
        }

        private void ConfigurePlace(EntityTypeBuilder<Place> builder)
        {
            builder.ToTable("Places");
            builder.HasKey(p => p.PlaceId);
            builder.Property(p => p.PlaceName).HasColumnType("varchar").HasMaxLength(30);
        }

        private void ConfigureBookings(EntityTypeBuilder<Bookings> builder)
        {
            builder.ToTable("Bookings");
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Email).HasColumnType("varchar").HasMaxLength(50);
            builder.Property(b => b.BookingTime).HasColumnType("varchar").HasMaxLength(5);
            builder.Property(b => b.PickupAddress).HasColumnType("varchar").HasMaxLength(200);
            builder.Property(b => b.Landmark).HasColumnType("varchar").HasMaxLength(30);
            builder.Property(b => b.PickupTime).HasColumnType("varchar").HasMaxLength(5);
            builder.Property(b => b.ContactNo).HasColumnType("varchar").HasMaxLength(25);
            builder.Property(b => b.Status).HasColumnType("varchar").HasMaxLength(30);
            builder.HasOne(b => b.CabType).WithMany(c => c.Bookings).HasForeignKey(b => b.CabTypeId);
            builder.HasOne(b => b.From).WithMany(p => p.BookingsFrom).HasForeignKey(b => b.FromPlace);
            builder.HasOne(b => b.To).WithMany(p => p.BookingsTo).HasForeignKey(b => b.ToPlace);
        }

        private void ConfigureBookingsHistory(EntityTypeBuilder<BookingsHistory> builder)
        {
            builder.ToTable("Bookings history");
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Email).HasColumnType("varchar").HasMaxLength(50);
            builder.Property(b => b.BookingTime).HasColumnType("varchar").HasMaxLength(5);
            builder.Property(b => b.PickupAddress).HasColumnType("varchar").HasMaxLength(200);
            builder.Property(b => b.Landmark).HasColumnType("varchar").HasMaxLength(30);
            builder.Property(b => b.PickupTime).HasColumnType("varchar").HasMaxLength(5);
            builder.Property(b => b.ContactNo).HasColumnType("varchar").HasMaxLength(25);
            builder.Property(b => b.Status).HasColumnType("varchar").HasMaxLength(30);
            builder.Property(b => b.Comp_time).HasColumnType("varchar").HasMaxLength(5);
            builder.Property(b => b.Feedback).HasColumnType("varchar").HasMaxLength(1000);
            builder.Property(b => b.Charge).HasColumnType("Money");
            builder.HasOne(b => b.CabType).WithMany(c => c.BookingsHistories).HasForeignKey(b => b.CabTypeId);
            builder.HasOne(b => b.From).WithMany(p => p.BookingsHistoriesFrom).HasForeignKey(b => b.FromPlace);
            builder.HasOne(b => b.To).WithMany(p => p.BookingsHistoriesTo).HasForeignKey(b => b.ToPlace);
        }


    }
}
