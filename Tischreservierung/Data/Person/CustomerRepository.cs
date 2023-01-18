using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Tischreservierung.Models.Person;

namespace Tischreservierung.Data.Person
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly OnlineReservationContext _context;

        public CustomerRepository(OnlineReservationContext context)
        {
            _context = context;
        }

        public void DeleteCustomer(Customer customer)
        {
            _context.Customers.Remove(customer);
        }

        public async Task<Customer?> GetCustomerByEMail(string mail)
        {
            return await _context.Customers.FindAsync(mail);
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public bool SetCustomer(Customer customer)
        {
            if (_context.Customers.Any(c => c.EMail.ToLower() == customer.EMail.ToLower()))
                return false;

            _context.Customers.Add(customer);

            return true;
        }
    }
}
