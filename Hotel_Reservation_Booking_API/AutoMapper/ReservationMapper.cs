using AutoMapper;
using Hotel_Reservation_Booking_Data_access.Models;
using Hotel_Reservation_Booking_DTOs.DTOs.RequestDTOs;
using Hotel_Reservation_Booking_DTOs.DTOs.ResponseDTOs;

namespace Hotel_Reservation_Booking_API.AutoMapper
{
    public class ReservationMapper : Profile
    {
        public ReservationMapper()
        {
            this.ReservationMapperOperation();
        }

        private void ReservationMapperOperation()
        {
            CreateMap<Reservation, GETReservationLessResultDTO>();
            CreateMap<INSERTReservationDTO, Reservation>();
            CreateMap<UPDATEReservationDTO, Reservation>();
        }
    }
}
