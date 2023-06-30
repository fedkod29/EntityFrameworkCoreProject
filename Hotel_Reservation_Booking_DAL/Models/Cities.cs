using Hotel_Reservation_Booking_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Reservation_Booking_Data_access.Models
{
    public class Cities : BaseModel
    {
        public string Title { get; set; } 

        public string PostalCode { get; set; }

        public Countries Countries { get; set; } = null!;

        public Guid CountriesID { get; set; }

        public ICollection<Companies> Companies { get; set; } = null!;

        public ICollection<Hotel> Hotels { get; set; } = null!; 
    }
}
