using Core.Models;

namespace Core.Contracts
{
    public interface IOpeningTimeRepository : IGenericRepository<RestaurantOpeningTime>
    {
        Task<IEnumerable<RestaurantOpeningTime>> GetByRestaurant(int id);
        Task<IEnumerable<RestaurantOpeningTime>> GetByDay(int day);
        Task<IEnumerable<RestaurantOpeningTime>> GetByDayAndRestaurant(int id, int day);
    }
}
