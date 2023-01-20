using Tischreservierung.Models.Person;

namespace Tischreservierung.Data.Person
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
