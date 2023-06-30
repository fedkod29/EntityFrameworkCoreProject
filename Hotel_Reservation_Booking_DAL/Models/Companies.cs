using Hotel_Reservation_Booking_DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Reservation_Booking_Data_access.Models
{
    public class Companies : BaseModel
    {
        public string Title { get; set; } 

        public string Details { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string Mobile { get; set; } 

        public string Address { get; set; } 

        public bool IsActive { get; set; } = false;

        public Cities Cities { get; set; } = null!;

        public Guid CitiesID { get; set; }

        public ICollection<Hotel> Hotels { get; set; } = null!;
    }
}
