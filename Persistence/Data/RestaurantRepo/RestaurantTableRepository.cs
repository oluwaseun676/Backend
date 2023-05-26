using Microsoft.EntityFrameworkCore;
using Core.Models;
using Core.Contracts;

namespace Persistence.Data.RestaurantRepo
{
    public class RestaurantTableRepository : GenericRepository<RestaurantTable>, IRestaurantTableRepository
    {
        public RestaurantTableRepository(OnlineReservationContext context) : base(context)
        {

        }

        public async Task<IEnumerable<RestaurantTable>> GetRestaurantTablesByRestaurant(int restaurantId)
        {
            return await _dbSet.Where(r => r.RestaurantId == restaurantId).ToListAsync();
        }
    }
}
