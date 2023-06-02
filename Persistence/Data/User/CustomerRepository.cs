using Core.Models.User;
using Core.Contracts;

namespace Persistence.Data.User
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(OnlineReservationContext context) : base(context)
        {
        }

        public async Task<Customer?> GetByEMail(string mail)
        {
            return await _dbSet.FindAsync(mail);
        }
    }
}
