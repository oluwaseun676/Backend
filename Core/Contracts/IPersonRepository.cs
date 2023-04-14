using Core.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Contracts
{
    public interface IPersonRepository
    {
        Task<Person?> CheckPassword(string email, string password);
    }
}
