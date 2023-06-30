using Hotel_Reservation_Booking_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Reservation_Booking_Data_access.Models
{
    public class RoomReserved : BaseModel
    {
        public decimal Price { get; set; }

        public Reservation Reservation { get; set; } = null!;

        public Guid ReservationID { get; set; }

        public Rooms Rooms { get; set; } = null!;

        public Guid RoomsID { get; set; }   
    }
}
