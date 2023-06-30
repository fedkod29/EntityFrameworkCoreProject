using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Hotel_Reservation_Booking_DAL.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RoomsCategoriesEnum
    {
        None,
        Standard,
        Deluxe,
        Suite,
        Family,
        Executive,
        Penthouse,
        Bungalow,
        Cottage,
        Villa,
        Beachfront
    }
}
