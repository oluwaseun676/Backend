using Core.Models.User;

namespace Core.Contracts
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        Task<Customer?> GetByEMail(string mail);

    }
}
