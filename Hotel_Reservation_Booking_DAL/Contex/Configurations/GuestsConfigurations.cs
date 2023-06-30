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
    public class GuestsConfigurations : IEntityTypeConfiguration<Guests>
    {
        public void Configure(EntityTypeBuilder<Guests> builder)
        {
            builder
                .HasMany(x => x.InvoiceGuests)
                .WithOne(x => x.Guests)
                .HasForeignKey(x => x.GuestsID)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(x => x.Reservations)
                .WithOne(x => x.Guests)
                .HasForeignKey(x => x.GuestsID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
