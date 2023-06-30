using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Reservation_Booking_DTOs.DTOs.ResponseDTOs
{
    public class GETInvoiceGuestsResultDTO
    {
        public DateTime IssuedDateTime { get; set; }
        
        public DateTime? PaidDateTime { get; set; }
        
        public DateTime? CanceledDateTime { get; set; }
    }
}
