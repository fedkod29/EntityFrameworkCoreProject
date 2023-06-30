using Hotel_Reservation_Booking_DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Reservation_Booking_Data_access.Models
{
    public class Hotel : BaseModel
    {
        [Required]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "This property has max length 100 characters")]
        public string Title { get; set; } 

        public string Description { get; set; }

        public bool IsActive { get; set; } = false;

        public HotelCategories HotelCategories { get; set; } = null!;

        public Guid HotelCategoriesID { get; set; } 

        public Cities Cities { get; set; } = null!; 

        public Guid CitiesID { get; set; }

        public Companies Companies { get; set; } = null!;

        public Guid CompaniesID { get; set; }

        public ICollection<Rooms> Rooms { get; set; } = null!;
    }
}
