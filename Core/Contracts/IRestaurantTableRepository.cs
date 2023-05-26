using Core.Models;

namespace Core.Contracts
{
    public interface IRestaurantTableRepository : IGenericRepository<RestaurantTable>
    {
        Task<IEnumerable<RestaurantTable>> GetRestaurantTablesByRestaurant(int restaurantId);
    }
}
