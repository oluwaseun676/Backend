using Core.Models;

namespace Core.Contracts
{
    public interface IRestaurantCategoryRepository
    {
        /// <summary>
        /// Gets all Categories with restaurant
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Category>> GetRestaurantCategories();
        /// <summary>
        /// Get one category with a list of all restaurants with the category
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Category?> GetRestaurantCategory(string id);
        /// <summary>
        /// Insert a new restaurantCategory
        /// </summary>
        /// <param name="restaurantCategory"></param>
        void InsertRestaurantCategory(Category restaurantCategory);
        /// <summary>
        /// Delete one restaurantCategory
        /// </summary>
        /// <param name="restaurantCategory"></param>
        void DeleteRestaurantCategory(Category restaurantCategory);
        Task Save();
    }
}
