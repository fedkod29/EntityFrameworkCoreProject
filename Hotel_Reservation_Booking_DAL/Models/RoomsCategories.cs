using Hotel_Reservation_Booking_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Reservation_Booking_Data_access.Models
{
    public class RoomsCategories : BaseModel
    {
        public string Title { get; set; }

        public ICollection<Rooms> Rooms { get; set; } = null!;
    }
}
