using Hotel_Reservation_Booking_DAL.Contex;
using Hotel_Reservation_Booking_DAL.Patterns;
using Hotel_Reservation_Booking_DAL.Repositories.Interfaces;
using Hotel_Reservation_Booking_Data_access.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Reservation_Booking_DAL.Repositories
{
    public class ReservationsRepository : GenericRepository<Reservation>, IReservationsRepository
    {
        public ReservationsRepository(HotelReservationBookingContext context) : base(context)
        {
        }
    }
}
