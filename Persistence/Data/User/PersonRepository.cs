using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Contracts;
using Core.Models.User;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Data.User
{
    public class PersonRepository : IPersonRepository
    {
        private readonly OnlineReservationContext _context;

        public PersonRepository(OnlineReservationContext context)
        {
            _context = context;
        }

        public async Task<Person?> CheckPassword(string email, string password)
        {
            return await _context.Persons.Where(p => p.EMail.ToLower() == email.ToLower() && password == p.Password).SingleOrDefaultAsync();
        }
    }
}
