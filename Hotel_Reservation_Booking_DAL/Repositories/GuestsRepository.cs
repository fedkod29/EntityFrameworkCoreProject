using Hotel_Reservation_Booking_Business_logic.DTOs.ResponseResultDTOs;
using Hotel_Reservation_Booking_DAL.Contex;
using Hotel_Reservation_Booking_DAL.Pagination.Parameters;
using Hotel_Reservation_Booking_DAL.Patterns;
using Hotel_Reservation_Booking_DAL.Repositories.Interfaces;
using Hotel_Reservation_Booking_Data_access.Models;
using Hotel_Reservation_Booking_DTOs.DTOs.ResponseDTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Reservation_Booking_DAL.Repositories
{
    public class GuestsRepository : GenericRepository<Guests>, IGuestsRepository
    {
        private readonly HotelReservationBookingContext _context;

        public GuestsRepository(HotelReservationBookingContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Guests>> ReturnAllGuestsWithPaginationAsync(GuestsParameters guestsParameters)
        {
            return await _context.Guests
                .OrderBy(x => x.FirstName)
                .Skip((guestsParameters.PageNumber - 1) * guestsParameters.PageSize)
                .Take(guestsParameters.PageSize)
                .ToListAsync();
        }

        public async Task<GETGuestRoomInfoResultDTO> ReturnAllInformationAboutGuestAsync(Guid ID)
        {
            var result = await _context.Guests
               .Include(g => g.Reservations)
               .Include(g => g.InvoiceGuests)
               .Where(g => g.ID == ID)
               .Select(g => new GETGuestRoomInfoResultDTO
               {
                   GuestID = g.ID,
                   FirstName = g.FirstName,
                   LastName = g.LastName,
                   Email = g.Email,
                   Mobile = g.Mobile,
                   Reservations = g.Reservations.Select(r => new GETReservationResultDTO
                   {
                       StartDateTime = r.StartDateTime,
                       EndDateTime = r.EndDateTime,
                       CreatedDateTime = r.CreatedDateTime,
                       DiscountPercent = r.DiscountPercent,
                       TotalPrice = r.TotalPrice,
                   }).ToList(),

                   InvoiceGuests = g.InvoiceGuests.Select(i => new GETInvoiceGuestsResultDTO
                   {
                       IssuedDateTime = i.IssuedDateTime,
                       PaidDateTime = i.PaidDateTime,
                       CanceledDateTime = i.CanceledDateTime,
                   }).ToList()
               }).AsNoTracking().FirstOrDefaultAsync();

            return result;
        }
    }
}
