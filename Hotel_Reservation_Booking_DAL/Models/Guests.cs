using Hotel_Reservation_Booking_DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Reservation_Booking_Data_access.Models
{
    public class Guests : BaseModel
    {
        [Required]
        [MaxLength(100, ErrorMessage = "This property has max length 100 characters")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "This property has max length 100 characters")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string Mobile { get; set; }

        public string Details { get; set; }

        public ICollection<Reservation> Reservations { get; set; } = null!;

        public ICollection<InvoiceGuests> InvoiceGuests { get; set; } = null!;
    }
}
