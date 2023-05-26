using Microsoft.EntityFrameworkCore;
using Core.Models.User;
using Core.Contracts;

namespace Persistence.Data.User
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(OnlineReservationContext context) : base(context)
        {
        }

        public async Task<List<Employee>> GetByRestaurant(int restaurantId)
        {
            return await _dbSet.Where(x => x.RestaurantId == restaurantId).ToListAsync();
        }
    }
}
