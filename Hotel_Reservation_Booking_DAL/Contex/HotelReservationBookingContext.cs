using Hotel_Reservation_Booking_DAL.Bogus;
using Hotel_Reservation_Booking_Data_access.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Reservation_Booking_DAL.Contex
{
    public class HotelReservationBookingContext : DbContext
    {
        public HotelReservationBookingContext(DbContextOptions<HotelReservationBookingContext> options) 
            : base(options) { }

        public DbSet<Cities> Cities { get; set; }
        public DbSet<Companies> Companies { get; set; }
        public DbSet<Countries> Countries { get; set; }
        public DbSet<Guests> Guests { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<HotelCategories> HotelCategories { get; set; }
        public DbSet<InvoiceGuests> InvoiceGuests { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<RoomReserved> RoomReserveds { get; set; }
        public DbSet<Rooms> Rooms { get; set; }
        public DbSet<RoomsCategories> RoomsCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            SeedingWithBogus bogus = new SeedingWithBogus();

            modelBuilder.Entity<RoomsCategories>().HasData(bogus.RoomsCategories);
            modelBuilder.Entity<HotelCategories>().HasData(bogus.HotelCategories);
            modelBuilder.Entity<Countries>().HasData(bogus.Countries);
            modelBuilder.Entity<Cities>().HasData(bogus.Cities);
            modelBuilder.Entity<Companies>().HasData(bogus.Companies);
            modelBuilder.Entity<Hotel>().HasData(bogus.Hotels);
            modelBuilder.Entity<Rooms>().HasData(bogus.Rooms);
            modelBuilder.Entity<Guests>().HasData(bogus.Guests);
            modelBuilder.Entity<Reservation>().HasData(bogus.Reservations);
            modelBuilder.Entity<InvoiceGuests>().HasData(bogus.InvoiceGuests);
            modelBuilder.Entity<RoomReserved>().HasData(bogus.RoomReserveds);
        }
    }
}
