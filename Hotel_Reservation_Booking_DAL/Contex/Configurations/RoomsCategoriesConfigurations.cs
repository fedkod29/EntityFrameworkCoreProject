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
    public class RoomsCategoriesConfigurations : IEntityTypeConfiguration<RoomsCategories>
    {
        public void Configure(EntityTypeBuilder<RoomsCategories> builder)
        {
            builder
                .HasMany(x => x.Rooms)
                .WithOne(x => x.RoomsCategories)
                .HasForeignKey(x => x.RoomsCategoriesID);
        }
    }
}
