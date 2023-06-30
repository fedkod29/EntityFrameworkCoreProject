using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Reservation_Booking_DTOs.DTOs.ResponseDTOs
{
    public class GETReservationResultDTO
    {
        public DateTime StartDateTime { get; set; }
        
        public DateTime EndDateTime { get; set; }
        
        public DateTime CreatedDateTime { get; set; }
        
        public DateTime? UpdateDateTime { get; set; }
        
        public decimal DiscountPercent { get; set; }
        
        public decimal TotalPrice { get; set; }
    }
}
