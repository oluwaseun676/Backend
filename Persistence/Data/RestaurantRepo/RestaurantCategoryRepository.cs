using Microsoft.EntityFrameworkCore;
using Core.Models;
using Core.Contracts;

namespace Persistence.Data.RestaurantRepo
{
    public class RestaurantCategoryRepository : IRestaurantCategoryRepository
    {
        private  readonly OnlineReservationContext _context;

        public RestaurantCategoryRepository(OnlineReservationContext context)
        {
            _context = context;
        }

        public void DeleteRestaurantCategory(Category restaurantCategory)
        {
            _context.Categories.Remove(restaurantCategory);
        }

        public async Task<Category?> GetRestaurantCategory(string id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task<IEnumerable<Category>> GetRestaurantCategories()
        {
            return await _context.Categories.ToListAsync();
        }

        public void InsertRestaurantCategory(Category restaurantCategory)
        {
            _context.Categories.Add(restaurantCategory);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
