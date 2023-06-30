using Hotel_Reservation_Booking_DAL.Contex;
using Hotel_Reservation_Booking_DAL.Patterns.Interfaces;
using Hotel_Reservation_Booking_DAL.Repositories;
using Hotel_Reservation_Booking_DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Reservation_Booking_DAL.Patterns
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HotelReservationBookingContext _context;

        public IGuestsRepository GuestsRepository { get; set; }
        public IReservationsRepository ReservationsRepository { get; set; }

        public UnitOfWork(HotelReservationBookingContext context)
        {
            _context = context;

            GuestsRepository = new GuestsRepository(_context);
            ReservationsRepository = new ReservationsRepository(_context);
        }

        public async Task Complete() => await _context.SaveChangesAsync();

        public void Dispose() => _context.Dispose();
    }
}
