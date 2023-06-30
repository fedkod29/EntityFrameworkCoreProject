using Hotel_Reservation_Booking_DAL.Contex;
using Hotel_Reservation_Booking_DAL.Models;
using Hotel_Reservation_Booking_DAL.Patterns.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Reservation_Booking_DAL.Patterns
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : BaseModel
    {
        private readonly HotelReservationBookingContext _context;

        private readonly DbSet<TEntity> _set;

        public GenericRepository(HotelReservationBookingContext context)
        {
            _context = context;

            _set = _context.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> ReturnAllModelsAsync()
        {
            return await _set.AsNoTracking().ToListAsync();
        }

        public async Task<TEntity> ReturnModelByIdAsync(Guid ID)
        {
            var result = await _set.AsNoTracking().FirstOrDefaultAsync(x => x.ID == ID);

            if (result is null)
            {
                throw new KeyNotFoundException($"The model with {ID} was not found!!! I am sorry...");
            }

            return result;
        }

        public async Task<TEntity> InsertModelAsync(TEntity entity)
        {
            await _set.AddAsync(entity);

            return entity;
        }

        public async Task<TEntity> UpdateModelAsync(TEntity entity)
        {
            var result = await _set.AsNoTracking().FirstOrDefaultAsync(x => x.ID == entity.ID);

            if (result is null)
            {
                throw new KeyNotFoundException($"The model with {entity.ID} was not found!!! I am sorry...");
            }

            _set.Update(entity);

            return entity;
        }

        public async Task<IEnumerable<TEntity>> DeleteModelAsync(Guid ID)
        {
            var result = await _set.AsNoTracking().FirstOrDefaultAsync(x => x.ID == ID);

            if (result is null)
            {
                throw new KeyNotFoundException($"The model with {ID} was not found!!! I am sorry...");
            }

            _set.Remove(result);

            return await _set.AsNoTracking().ToListAsync();
        }
    }
}
