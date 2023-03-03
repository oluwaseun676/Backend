using Core.Models;

namespace Core.Contracts
{
    public interface IRestaurantRepository
    {
        Task<IEnumerable<Restaurant>> GetRestaurants();
        Task<Restaurant?> GetRestaurantById(int id);
        bool InsertRestaurant(Restaurant restaurant);
        void DeleteRestaurant(Restaurant restaurant);
        void UpdateRestaurant(Restaurant restaurant);
        Task Save();
    }
}
