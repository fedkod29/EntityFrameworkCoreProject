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
    public class CompaniesConfigurations : IEntityTypeConfiguration<Companies>
    {
        public void Configure(EntityTypeBuilder<Companies> builder)
        {
            builder
               .HasMany(x => x.Hotels)
               .WithOne(x => x.Companies)
               .HasForeignKey(x => x.CompaniesID)
               .OnDelete(DeleteBehavior.NoAction);

            builder
                .Property(x => x.Title)
                .IsRequired().HasMaxLength(100);

            builder
                .Property(x => x.Address)
                .IsRequired().HasMaxLength(100);
        }
    }
}
