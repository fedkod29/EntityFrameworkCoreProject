using Hotel_Reservation_Booking_BLL.Services;
using Hotel_Reservation_Booking_BLL.Services.Interfaces;
using Hotel_Reservation_Booking_Business_logic.DTOs.ResponseResultDTOs;
using Hotel_Reservation_Booking_DTOs.DTOs.RequestDTOs;
using Hotel_Reservation_Booking_DTOs.DTOs.RequestResultDTOs;
using Hotel_Reservation_Booking_DTOs.DTOs.ResponseDTOs;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Reservation_Booking_API.Controllers
{
    [ApiController]
    [Route("api/Reservation")]
    public class ReservationController : Controller
    {
        private readonly IReservationService _reservationService;
        private readonly ILogger<ReservationController> _logger;

        public ReservationController(IReservationService reservationService, ILogger<ReservationController> logger)
        {
            _reservationService = reservationService;
            _logger = logger;
        }

        [HttpGet, Route("Return_all_Reservation_Async")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<GETReservationLessResultDTO>>> ReturnReservationLessResultAsync()
        {
            try
            {
                _logger.LogInformation("Fetching all Reservation from database...");
                var result = await _reservationService.ReturnAllReservationAsync();

                _logger.LogInformation("Everything was OK! We fetched data without problem!!!");
                return Ok(result);
            }
            catch (Exception exception)
            {
                _logger.LogError($"Something went wrong in {nameof(ReservationController)} Controller!!! {exception.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost, Route("Inser_Reservation_Async")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<GETReservationLessResultDTO>> InsertingReservationAsync(INSERTReservationDTO InsertReservationDTO)
        {
            try
            {
                _logger.LogInformation("Inserting Reservation by ID from database...");

                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }

                var result = await _reservationService.InsertReservationAsync(InsertReservationDTO);

                _logger.LogInformation("Everything was OK! We inser data without problem!!!");
                return Ok(result);
            }
            catch (Exception exception)
            {
                _logger.LogError($"Something went wrong in {nameof(GuestController)} Controller!!! {exception.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
