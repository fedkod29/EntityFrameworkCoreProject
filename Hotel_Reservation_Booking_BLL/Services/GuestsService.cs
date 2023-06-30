using AutoMapper;
using Hotel_Reservation_Booking_BLL.Services.Interfaces;
using Hotel_Reservation_Booking_Business_logic.DTOs.ResponseResultDTOs;
using Hotel_Reservation_Booking_DAL.Pagination.Parameters;
using Hotel_Reservation_Booking_DAL.Patterns.Interfaces;
using Hotel_Reservation_Booking_Data_access.Models;
using Hotel_Reservation_Booking_DTOs.DTOs.RequestResultDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Reservation_Booking_BLL.Services
{
    public class GuestsService : IGuestsService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public GuestsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;

            _mapper = mapper;
        }

        public async Task<IEnumerable<GETGuestsResultDTO>> DeleteGuestsByIdAsync(Guid ID)
        {
            var result = await _unitOfWork.GuestsRepository.DeleteModelAsync(ID);

            await _unitOfWork.Complete();

            return _mapper.Map<IEnumerable<Guests>, IEnumerable<GETGuestsResultDTO>>(result);
        }

        public async Task<GETGuestsResultDTO> InsertGuestsAsync(INSERGuestResultDTO InsertGuestResultDTO)
        {
            var result = await _unitOfWork.GuestsRepository.InsertModelAsync(_mapper.Map<Guests>(InsertGuestResultDTO));

            await _unitOfWork.Complete();

            return _mapper.Map<GETGuestsResultDTO>(result);
        }

        public async Task<IEnumerable<GETGuestsResultDTO>> ReturnAllGuestsAsync()
        {
            var result = await _unitOfWork.GuestsRepository.ReturnAllModelsAsync();

            return _mapper.Map<IEnumerable<Guests>, IEnumerable<GETGuestsResultDTO>>(result);
        }

        public async Task<IEnumerable<GETGuestsResultDTO>> ReturnAllGuestsWithPaginationAsync(GuestsParameters guestsParameters)
        {
            var result = await _unitOfWork.GuestsRepository.ReturnAllGuestsWithPaginationAsync(guestsParameters);

            return _mapper.Map<IEnumerable<Guests>, IEnumerable<GETGuestsResultDTO>>(result);
        }

        public async Task<GETGuestRoomInfoResultDTO> ReturnAllInformationAboutGuestAsync(Guid ID)
        {
            var result = await _unitOfWork.GuestsRepository.ReturnAllInformationAboutGuestAsync(ID);

            return _mapper.Map<GETGuestRoomInfoResultDTO>(result);
        }

        public async Task<GETGuestsResultDTO> ReturnGuestsByIdAsync(Guid ID)
        {
            var result = await _unitOfWork.GuestsRepository.ReturnModelByIdAsync(ID);

            return _mapper.Map<GETGuestsResultDTO>(result);
        }

        public async Task<GETGuestsResultDTO> UpdateGuestsAsync(UPDATEGuestResultDTO UpdateGuestResultDTO)
        {
            var result = await _unitOfWork.GuestsRepository.UpdateModelAsync(_mapper.Map<Guests>(UpdateGuestResultDTO));

            await _unitOfWork.Complete();

            return _mapper.Map<GETGuestsResultDTO>(result);
        }
    }
}
