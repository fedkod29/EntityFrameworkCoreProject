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
    public class CountriesConfigurations : IEntityTypeConfiguration<Countries>
    {
        public void Configure(EntityTypeBuilder<Countries> builder)
        {
            builder
                .HasMany(x => x.Cities)
                .WithOne(x => x.Countries)
                .HasForeignKey(x => x.CountriesID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
