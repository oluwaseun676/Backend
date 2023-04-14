using Microsoft.EntityFrameworkCore;
using Core.Models;
using Core.Contracts;
using Core.DTO;
using Core.Models.Person;

namespace Persistence.Data.RestaurantRepo
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
        public async Task<Restaurant> InsertRestaurantAsync(DTO_RestaurantPost restaurant)
        {
            Restaurant res = new Restaurant()
            {
                Name = restaurant.Name,
                Address = restaurant.Address,
                StreetNr = restaurant.StreetNr,
                ZipCodeId = restaurant.ZipCode!.Id,
                Categories = _context.Categories.Where(c => restaurant.Categories!.Contains(c)).ToList()
            };

            Employee emp = restaurant.Employee!;
            emp.Restaurant = res;
            RestaurantOpeningTime[] openings = restaurant.Openings!.Select(o => new RestaurantOpeningTime()
            {
                Day = o.Day,
                OpeningTime = new DateTime(2000, 1, 1, Int32.Parse(o.OpenFrom.Split(':')[0])
                , Int32.Parse(o.OpenFrom.Split(':')[1]),0),
                ClosingTime = new DateTime(2000, 1, 1, Int32.Parse(o.OpenTo.Split(':')[0])
                , Int32.Parse(o.OpenTo.Split(':')[1]), 0),
                Restaurant = res


            }).ToArray();

            await _context.Restaurants.AddAsync(res);
            await _context.RestaurantOpeningTimes.AddRangeAsync(openings);
            await _context.Employees.AddAsync(emp);
            return res;
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
