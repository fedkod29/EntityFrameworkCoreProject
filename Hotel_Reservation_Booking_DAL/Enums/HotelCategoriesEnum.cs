using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Hotel_Reservation_Booking_DAL.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum HotelCategoriesEnum
    {
        None,
        Economy,
        MidRange,
        Luxury,
        Boutique,
        Resort,
        BedAndBreakfast,
        ExtendedStay,
        Spa,
        Historic,
        Casino
    }
}
