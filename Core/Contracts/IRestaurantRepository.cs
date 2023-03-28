using Core.DTO;
using Core.Models;

namespace Core.Contracts
{
    public interface IRestaurantRepository
    {
        Task<IEnumerable<Restaurant>> GetRestaurants();
        Task<Restaurant?> GetRestaurantById(int id);

        Task<Restaurant> InsertRestaurantAsync(DTO_RestaurantPost restaurant);
        void DeleteRestaurant(Restaurant restaurant);
        void UpdateRestaurant(Restaurant restaurant);
        Task Save();
    }
}
