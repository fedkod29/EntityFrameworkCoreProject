using Hotel_Reservation_Booking_DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Reservation_Booking_DAL.Patterns.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task Complete();

        IGuestsRepository GuestsRepository { get; set; }

        IReservationsRepository ReservationsRepository { get; set; }
    }
}
