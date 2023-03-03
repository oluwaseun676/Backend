using Microsoft.EntityFrameworkCore;
using Core.Models;
using Core.Contracts;

namespace Tischreservierung.Data.RestaurantRepo
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private  readonly OnlineReservationContext _context;

        public RestaurantRepository(OnlineReservationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Restaurant>> GetRestaurants()
        {
            return await _context.Restaurants.ToListAsync();
        }

        public async Task<Restaurant?> GetRestaurantById(int id)
        {
            return await _context.Restaurants.FindAsync(id);
        }
        public bool InsertRestaurant(Restaurant restaurant)
        {
            if (_context.Zipcodes.Contains(restaurant.ZipCode))
            {
                _context.Restaurants.Add(restaurant);
                return true;
            }

            return false;
        }

        public void DeleteRestaurant(Restaurant restaurant)
        {
            _context.Restaurants.Remove(restaurant);
        }

        public void UpdateRestaurant(Restaurant restaurant)
        {
            _context.Restaurants.Update(restaurant);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
