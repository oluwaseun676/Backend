using Core.Models.User;

namespace Core.Contracts
{
    public interface IEmployeeRepository
    {
        void SetEmployee(Employee employee);
        void DeleteEmployee(Employee employee);

        Task<Employee?> GetEmployeeById(int personId);
        Task<List<Employee>> GetByRestaurantId(int restaurantId);

        Task Save();
    }
}
