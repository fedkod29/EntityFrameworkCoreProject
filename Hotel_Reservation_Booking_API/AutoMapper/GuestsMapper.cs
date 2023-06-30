using AutoMapper;
using Hotel_Reservation_Booking_Business_logic.DTOs.ResponseResultDTOs;
using Hotel_Reservation_Booking_Data_access.Models;
using Hotel_Reservation_Booking_DTOs.DTOs.RequestResultDTOs;

namespace Hotel_Reservation_Booking_API.AutoMapper
{
    public class GuestsMapper : Profile
    {
        public GuestsMapper()
        {
            GuestsMappingOperation();
        }

        private void GuestsMappingOperation()
        {
            CreateMap<Guests, GETGuestsResultDTO>()
                .ForMember(dest => dest.FullName, 
                options => options.MapFrom(src => $"{src.FirstName} {src.LastName}"));

            CreateMap<Guests, GETGuestRoomInfoResultDTO>();

            CreateMap<INSERGuestResultDTO, Guests>();

            CreateMap<UPDATEGuestResultDTO, Guests>();
        }
    }
}
