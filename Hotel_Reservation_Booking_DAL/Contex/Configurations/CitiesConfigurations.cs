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
    public class CitiesConfigurations : IEntityTypeConfiguration<Cities>
    {
        public void Configure(EntityTypeBuilder<Cities> builder)
        {
            builder
                .HasMany(x => x.Hotels)
                .WithOne(x => x.Cities)
                .HasForeignKey(x => x.CitiesID)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
