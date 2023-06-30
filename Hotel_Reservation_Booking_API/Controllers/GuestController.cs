using Bogus;
using FluentValidation;
using Hotel_Reservation_Booking_BLL.Services.Interfaces;
using Hotel_Reservation_Booking_Business_logic.DTOs.ResponseResultDTOs;
using Hotel_Reservation_Booking_DAL.Pagination.Parameters;
using Hotel_Reservation_Booking_Data_access.Models;
using Hotel_Reservation_Booking_DTOs.DTOs.RequestResultDTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.DataAnnotations;

namespace Hotel_Reservation_Booking_API.Controllers
{
    [ApiController]
    [Route("api/guests")]
    public class GuestController : Controller
    {
        private readonly IGuestsService _guestService;

        private readonly ILogger<GuestController> _logger;

        public GuestController(IGuestsService guestService, ILogger<GuestController> logger)
        {
            _guestService = guestService;

            _logger = logger;
        }

        /// <summary>
        /// Returning add data from table Guests 
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("Return_all_Guest_Async")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<GETGuestsResultDTO>>> ReturnAllGuestAsync()
        {
            try
            {
                _logger.LogInformation("Fetching all Guests from database...");
                var result = await _guestService.ReturnAllGuestsAsync();

                _logger.LogInformation("Everything was OK! We fetched data without problem!!!");
                return Ok(result);
            }
            catch (Exception exception)
            {
                _logger.LogError($"Something went wrong in {nameof(GuestController)} Controller!!! {exception.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Returning add data from table Guests  with Pagination
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("Return_all_Guest_with_Pagination_Async")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<GETGuestsResultDTO>>> ReturnAllGuestsWithPaginationAsync([FromQuery] GuestsParameters guestsParameters)
        {
            try
            {
                _logger.LogInformation("Fetching all Guests from database...");
                var result = await _guestService.ReturnAllGuestsWithPaginationAsync(guestsParameters);

                _logger.LogInformation("Everything was OK! We fetched data without problem!!!");
                return Ok(result);
            }
            catch (Exception exception)
            {
                _logger.LogError($"Something went wrong in {nameof(GuestController)} Controller!!! {exception.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Returnin all information about the Guest by ID 
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpGet, Route("Return_all_Guest_Information_By_ID_Async")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<GETGuestRoomInfoResultDTO>> ReturnAllGuestInformationByIdAsync(Guid ID)
        {
            try
            {
                _logger.LogInformation("Fetching all Guests from database...");
                var result = await _guestService.ReturnAllInformationAboutGuestAsync(ID);

                _logger.LogInformation("Everything was OK! We fetched data without problem!!!");
                return Ok(result);
            }
            catch (Exception exception)
            {
                _logger.LogError($"Something went wrong in {nameof(GuestController)} Controller!!! {exception.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Returnin the concrete Guest by ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpGet, Route("Return_Guest_By_ID_Async")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GETGuestsResultDTO>> ReturnGuestByIDAsync(Guid ID)
        {
            try
            {
                _logger.LogInformation("Fetching all Guests from database...");
                var result = await _guestService.ReturnGuestsByIdAsync(ID);

                if (result is null)
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }

                _logger.LogInformation("Everything was OK! We fetched data without problem!!!");
                return Ok(result);
            }
            catch (Exception exception)
            {
                _logger.LogError($"Something went wrong in {nameof(GuestController)} Controller!!! {exception.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Updating the Guest in database
        /// </summary>
        /// <param name="updateGuestResultDTO"></param>
        /// <returns></returns>
        [HttpPut, Route("Update_Guest_Async")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GETGuestsResultDTO>> UpdateGuestAsync(UPDATEGuestResultDTO updateGuestResultDTO)
        {
            try
            {
                _logger.LogInformation("Updaing Guest by ID from database...");
                var result = await _guestService.UpdateGuestsAsync(updateGuestResultDTO);

                if (result is null)
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }

                _logger.LogInformation("Everything was OK! We update data without problem!!!");
                return Ok(result);
            }
            catch (Exception exception)
            {
                _logger.LogError($"Something went wrong in {nameof(GuestController)} Controller!!! {exception.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Insering the Guest into database
        /// </summary>
        /// <param name="insertGuestResultDTO"></param>
        /// <returns></returns>
        [HttpPost, Route("Inser_Guest_Async")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<GETGuestsResultDTO>> InsertingGuestAsync(INSERGuestResultDTO insertGuestResultDTO)
        {
            try
            {
                _logger.LogInformation("Inserting Guest by ID from database...");
                var result = await _guestService.InsertGuestsAsync(insertGuestResultDTO);

                _logger.LogInformation("Everything was OK! We inser data without problem!!!");
                return Ok(result);
            }
            catch (Exception exception)
            {
                _logger.LogError($"Something went wrong in {nameof(GuestController)} Controller!!! {exception.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Deleting the Guest by ID from database
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpDelete, Route("Deleting_Guest_By_Id_Async/{ID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<GETGuestsResultDTO>>> DeleteGuestByIdAsync(Guid ID)
        {
            try
            {
                _logger.LogInformation("Deleting Guest by ID from database...");
                var result = await _guestService.DeleteGuestsByIdAsync(ID);

                _logger.LogInformation("Everything was OK! We deleted data without problem!!!");
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
