using Core.Contracts;
using Core.Models.User;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Data.User
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        public PersonRepository(OnlineReservationContext context) : base(context)
        {
        }

        public async Task<Person?> CheckPassword(string email, string password)
        {
            return await _dbSet.Where(p => p.EMail.ToLower() == email.ToLower() && password == p.Password).SingleOrDefaultAsync();
        }
    }
}
