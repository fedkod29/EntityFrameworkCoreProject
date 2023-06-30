using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Reservation_Booking_DTOs.DTOs.RequestDTOs
{
    public class UPDATEReservationDTO
    {
        public DateTime EndDateTime { get; set; }

        public DateTime? UpdateDateTime { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
