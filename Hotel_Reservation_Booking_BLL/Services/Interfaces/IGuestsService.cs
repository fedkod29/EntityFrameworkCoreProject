using Hotel_Reservation_Booking_Business_logic.DTOs.ResponseResultDTOs;
using Hotel_Reservation_Booking_DAL.Pagination.Parameters;
using Hotel_Reservation_Booking_DTOs.DTOs.RequestResultDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Reservation_Booking_BLL.Services.Interfaces
{
    public interface IGuestsService
    {
        Task<IEnumerable<GETGuestsResultDTO>> ReturnAllGuestsAsync();

        Task<GETGuestsResultDTO> ReturnGuestsByIdAsync(Guid ID);

        Task<GETGuestsResultDTO> InsertGuestsAsync(INSERGuestResultDTO InsertGuestResultDTO);

        Task<GETGuestsResultDTO> UpdateGuestsAsync(UPDATEGuestResultDTO UpdateGuestResultDTO);

        Task<IEnumerable<GETGuestsResultDTO>> DeleteGuestsByIdAsync(Guid ID);

        Task<GETGuestRoomInfoResultDTO> ReturnAllInformationAboutGuestAsync(Guid ID);

        Task<IEnumerable<GETGuestsResultDTO>> ReturnAllGuestsWithPaginationAsync(GuestsParameters guestsParameters);
    }
}
