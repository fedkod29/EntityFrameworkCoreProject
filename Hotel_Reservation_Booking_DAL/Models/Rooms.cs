using Hotel_Reservation_Booking_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Reservation_Booking_Data_access.Models
{
    public class Rooms : BaseModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public Hotel Hotel { get; set; } = null!;

        public Guid HotelID { get; set; }

        public RoomsCategories RoomsCategories { get; set; } = null!;

        public Guid RoomsCategoriesID { get; set; }

        public ICollection<RoomReserved> RoomReserveds { get; set; } = null!;
    }
}
