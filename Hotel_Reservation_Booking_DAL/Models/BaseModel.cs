using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Reservation_Booking_DAL.Models
{
    public abstract class BaseModel
    {
        [Key]
        public Guid ID { get; set; }

        public BaseModel()
        {
            ID = Guid.NewGuid();
        }
    }
}
