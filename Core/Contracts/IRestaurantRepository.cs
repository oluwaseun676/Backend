using Core.DTO;
using Core.Models;

namespace Core.Contracts
{
    public interface IRestaurantRepository : IGenericRepository<Restaurant>
    {
        Task<Restaurant?> InsertRestaurantAsync(RestaurantPostDto restaurant);

        Task<RestaurantViewDto?> GetRestaurantForViewById(int id);
    }
}
