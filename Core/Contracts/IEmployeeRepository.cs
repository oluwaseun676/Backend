using Core.Models.User;

namespace Core.Contracts
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        Task<List<Employee>> GetByRestaurant(int restaurantId);
    }
}
