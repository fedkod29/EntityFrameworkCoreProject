using Hotel_Reservation_Booking_Data_access.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Reservation_Booking_DAL.Contex.Configurations
{
    internal class HotelCategoriesConfigurations : IEntityTypeConfiguration<HotelCategories>
    {
        public void Configure(EntityTypeBuilder<HotelCategories> builder)
        {
            builder
                .HasMany(x => x.Hotels)
                .WithOne(x => x.HotelCategories)
                .HasForeignKey(x => x.HotelCategoriesID)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
