using Microsoft.EntityFrameworkCore;
using Core.Models.User;
using Core.Contracts;

namespace Persistence.Data.User
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly OnlineReservationContext _context;

        public EmployeeRepository(OnlineReservationContext context)
        {
            _context = context;
        }

        public void DeleteEmployee(Employee employee)
        {
            _context.Employees.Remove(employee);
        }

        public async Task<List<Employee>> GetByRestaurantId(int restaurantId)
        {
            return await _context.Employees.Where(x => x.RestaurantId == restaurantId).ToListAsync();
        }

        public async Task<Employee?> GetEmployeeById(int personId)
        {
            return await _context.Employees.FindAsync(personId);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public void SetEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
        }
    }
}
