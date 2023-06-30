using Hotel_Reservation_Booking_Data_access.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Reservation_Booking_DAL.Contex.Configurations
{
    public class RoomsConfigurations : IEntityTypeConfiguration<Rooms>
    {
        public void Configure(EntityTypeBuilder<Rooms> builder)
        {
            builder
                .HasMany(x => x.RoomReserveds)
                .WithOne(x => x.Rooms)
                .HasForeignKey(x => x.RoomsID)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .Property(x => x.Title)
                .IsRequired().HasMaxLength(100);

            builder
                .Property(x => x.Price)
                .HasColumnName("PriceForRoom");
        }
    }
}
