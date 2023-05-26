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

        //public bool SetCustomer(Customer customer)
        //{
        //    if (_context.Customers.Any(c => c.EMail.ToLower() == customer.EMail.ToLower()))
        //        return false;

        //    _context.Customers.Add(customer);

        //    return true;
        //}
    }
}
