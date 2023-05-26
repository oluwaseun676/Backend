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
        public async Task<RestaurantViewDto?> GetRestaurantForViewById(int id)
        {
            return await _dbContext.Restaurants.Where(x => x.Id == id).Select(x => new RestaurantViewDto()
            {
                Id = x.Id,
                StreetNr = x.StreetNr,
                Address = x.Address,
                ZipCode = x.ZipCode,
                Openings = _dbContext.RestaurantOpeningTimes.Where(y => y.RestaurantId == x.Id)
                    .Select(o => new OpeningTimeDto() { Day = o.Day, 
                        OpenFrom = o.OpeningTime.Hour + ":" + o.OpeningTime.Minute, 
                        OpenTo = o.ClosingTime.Hour + ":" + o.ClosingTime.Minute}).ToArray(),
                Name = x.Name,
                Categories = x.Categories.ToArray(),
            }).SingleOrDefaultAsync();
        }
    }
}
