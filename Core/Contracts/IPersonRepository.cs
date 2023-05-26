using Core.Models.User;

namespace Core.Contracts
{
    public interface IPersonRepository : IGenericRepository<Person>
    {
        Task<Person?> CheckPassword(string email, string password);
    }
}
