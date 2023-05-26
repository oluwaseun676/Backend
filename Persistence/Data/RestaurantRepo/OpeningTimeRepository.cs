using Microsoft.EntityFrameworkCore;
using Core.Models;
using Core.Contracts;

namespace Persistence.Data.RestaurantRepo
{
    public class OpeningTimeRepository : GenericRepository<RestaurantOpeningTime>, IOpeningTimeRepository
    {
        public OpeningTimeRepository(OnlineReservationContext context) : base(context)
        {
            
        }

        public async Task<IEnumerable<RestaurantOpeningTime>> GetByDay(int day)
        {
            return await _dbSet.Where(oT => oT.Day == day).ToListAsync();
        }

        public async Task<IEnumerable<RestaurantOpeningTime>> GetByDayAndRestaurant(int id, int day)
        {
            return await _dbSet.Where(oT => oT.Day == day && oT.RestaurantId == id).ToListAsync();
        }

        public async Task<IEnumerable<RestaurantOpeningTime>> GetByRestaurant(int id)
        {
            return await _dbSet.Where(oT => oT.RestaurantId == id).ToListAsync();
        }
    }
}
