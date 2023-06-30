using AutoMapper;
using Hotel_Reservation_Booking_BLL.Services.Interfaces;
using Hotel_Reservation_Booking_DAL.Patterns.Interfaces;
using Hotel_Reservation_Booking_Data_access.Models;
using Hotel_Reservation_Booking_DTOs.DTOs.RequestDTOs;
using Hotel_Reservation_Booking_DTOs.DTOs.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Reservation_Booking_BLL.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ReservationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GETReservationLessResultDTO> InsertReservationAsync(INSERTReservationDTO InsertReservationDTO)
        {
            var InsertReservationDTOWithMapper = _mapper.Map<Reservation>(InsertReservationDTO);
            var reservation = await _unitOfWork.ReservationsRepository.InsertModelAsync(InsertReservationDTOWithMapper);
            var result = _mapper.Map<GETReservationLessResultDTO>(reservation);

            await _unitOfWork.Complete();
            return result;
        }

        public async Task<IEnumerable<GETReservationLessResultDTO>> ReturnAllReservationAsync()
        {
            var reservation = await _unitOfWork.ReservationsRepository.ReturnAllModelsAsync();
            var result = _mapper.Map<IEnumerable<Reservation>, IEnumerable<GETReservationLessResultDTO>>(reservation);

            return result;
        }
    }
}
