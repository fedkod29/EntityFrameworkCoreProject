using Hotel_Reservation_Booking_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Reservation_Booking_DAL.Patterns.Interfaces
{
    public interface IGenericRepository<TEntity>
        where TEntity : BaseModel
    {
        Task<IEnumerable<TEntity>> ReturnAllModelsAsync();

        Task<TEntity> ReturnModelByIdAsync(Guid ID);

        Task<TEntity> InsertModelAsync(TEntity entity);

        Task<TEntity> UpdateModelAsync(TEntity entity);

        Task<IEnumerable<TEntity>> DeleteModelAsync(Guid ID);
    }
}
