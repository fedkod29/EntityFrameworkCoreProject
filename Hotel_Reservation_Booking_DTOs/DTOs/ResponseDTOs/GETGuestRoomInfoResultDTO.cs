using Hotel_Reservation_Booking_DTOs.DTOs.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Reservation_Booking_Business_logic.DTOs.ResponseResultDTOs
{
    public class GETGuestRoomInfoResultDTO
    {
        public Guid GuestID { get; set; }

        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string Email { get; set; }
        
        public string Mobile { get; set; }
        
        public string Details { get; set; }
        
        public List<GETReservationResultDTO> Reservations { get; set; }
        
        public List<GETInvoiceGuestsResultDTO> InvoiceGuests { get; set; }
    }
}
