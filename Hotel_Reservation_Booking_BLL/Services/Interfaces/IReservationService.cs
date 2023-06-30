using Hotel_Reservation_Booking_Business_logic.DTOs.ResponseResultDTOs;
using Hotel_Reservation_Booking_DTOs.DTOs.RequestDTOs;
using Hotel_Reservation_Booking_DTOs.DTOs.RequestResultDTOs;
using Hotel_Reservation_Booking_DTOs.DTOs.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Reservation_Booking_BLL.Services.Interfaces
{
    public interface IReservationService
    {
        Task<IEnumerable<GETReservationLessResultDTO>> ReturnAllReservationAsync();

        //Task<GETReservationLessResultDTO> ReturnReservationByIdAsync(Guid ID);

        Task<GETReservationLessResultDTO> InsertReservationAsync(INSERTReservationDTO InsertReservationDTO);

        //Task<GETReservationLessResultDTO> UpdateReservationAsync(UPDATEReservationDTO UpdateReservationDTO);

        //Task<IEnumerable<GETReservationLessResultDTO>> DeleteReservationByIdAsync(Guid ID);
    }
}
