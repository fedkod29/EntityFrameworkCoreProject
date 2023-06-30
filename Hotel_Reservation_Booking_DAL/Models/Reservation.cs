using Hotel_Reservation_Booking_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Reservation_Booking_Data_access.Models
{
    public class Reservation : BaseModel
    {
        public DateTime StartDateTime { get; set; } 

        public DateTime EndDateTime { get; set; }

        public DateTime CreatedDateTime { get; set; } 

        public DateTime? UpdatedDateTime { get; set; } 

        public decimal DiscountPercent { get; set; } 

        public decimal TotalPrice { get; set; }

        public Guests Guests { get; set; } = null!;

        public Guid GuestsID { get; set; } 

        public ICollection<InvoiceGuests> InvoicesGuests { get; set; } = null!;

        public ICollection<RoomReserved> RoomReserved { get; set; } = null!;
    }
}
