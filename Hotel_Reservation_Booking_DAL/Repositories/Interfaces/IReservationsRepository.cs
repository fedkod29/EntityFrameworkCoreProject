using Hotel_Reservation_Booking_DAL.Patterns.Interfaces;
using Hotel_Reservation_Booking_Data_access.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Reservation_Booking_DAL.Repositories.Interfaces
{
    public interface IReservationsRepository : IGenericRepository<Reservation>
    {
    }
}
