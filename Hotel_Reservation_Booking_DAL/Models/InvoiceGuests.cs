using Hotel_Reservation_Booking_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Reservation_Booking_Data_access.Models
{
    public class InvoiceGuests : BaseModel
    {
        public DateTime IssuedDateTime { get; set; }  
        
        public DateTime? PaidDateTime { get; set; }  
       
        public DateTime? CanceledDateTime { get; set; }

        public Guests Guests { get; set; } = null!;

        public Guid GuestsID { get; set; } 

        public Reservation Reservation { get; set; } = null!;   

        public Guid ReservationID { get; set; }
    }
}
