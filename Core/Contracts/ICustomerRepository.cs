using Core.Models.Person;

namespace Core.Contracts
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetCustomers();
        Task<Customer?> GetCustomerByEMail(string mail);

        bool SetCustomer(Customer customer);
        void DeleteCustomer(Customer customer);

        Task Save();
    }
}
