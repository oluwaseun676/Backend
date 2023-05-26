using Microsoft.EntityFrameworkCore;
using Core.Models;
using Core.Contracts;
using Core.DTO;
using Core.Models.User;

namespace Persistence.Data.RestaurantRepo
{
    public class RestaurantRepository : GenericRepository<Restaurant>, IRestaurantRepository
    {
        public RestaurantRepository(OnlineReservationContext context) : base(context)
        {
            
        }

        public async Task<Restaurant?> InsertRestaurantAsync(RestaurantPostDto restaurant)
        {
            if (_dbContext.Persons.Count(p => p.EMail == restaurant.Employee!.EMail) != 0)
                return null;

            Restaurant res = new Restaurant()
            {
                Name = restaurant.Name,
                Address = restaurant.Address,
                StreetNr = restaurant.StreetNr,
                ZipCodeId = restaurant.ZipCode!.Id
            };
            if (restaurant.Categories != null)
                res.Categories = _dbContext.Categories.Where(c => restaurant.Categories!.Contains(c)).ToList();

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

            _dbContext.Restaurants.Add(res);
            await _dbContext.RestaurantOpeningTimes.AddRangeAsync(openings);
            await _dbContext.Employees.AddAsync(emp);
            return res;
        }
    }
}
