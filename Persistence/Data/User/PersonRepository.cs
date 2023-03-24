using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Contracts;
using Core.Models.User;

namespace Persistence.Data.User
{
    public class PersonRepository : IPersonRepository
    {
        private readonly OnlineReservationContext _context;

        public PersonRepository(OnlineReservationContext context)
        {
            _context = context;
        }

        public Person? CheckPassword(string email, string password)
        {
            return _context.Persons.Where(p => p.EMail == email && password == p.Password).SingleOrDefault();
        }
    }
}
