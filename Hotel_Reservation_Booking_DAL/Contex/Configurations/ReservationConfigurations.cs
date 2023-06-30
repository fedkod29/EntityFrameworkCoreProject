using Hotel_Reservation_Booking_Data_access.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Reservation_Booking_DAL.Contex.Configurations
{
    public class ReservationConfigurations : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder
                .HasMany(x => x.RoomReserved)
                .WithOne(x => x.Reservation)
                .HasForeignKey(x => x.ReservationID);
        }
    }
}
